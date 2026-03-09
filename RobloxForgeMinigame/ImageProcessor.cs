using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Extensions;

// Для разрешения конфликта имён System.Drawing.Point и OpenCvSharp.Point
using CvPoint = OpenCvSharp.Point;
using SysPoint = System.Drawing.Point;
using SysSize = System.Drawing.Size;

namespace RobloxForgeMinigame;

public static class ImageProcessor
{
    private const int Tolerance = 15; // Погрешность сравнения цветов

    /// <summary>
    /// Быстрый захват прямоугольного участка экрана в Bitmap.
    /// </summary>
    public static Bitmap CaptureScreen(int x, int y, int width, int height)
    {
        var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        using var g = Graphics.FromImage(bmp);
        
        g.CopyFromScreen(x, y, 0, 0, new SysSize(width, height), CopyPixelOperation.SourceCopy);
        
        return bmp;
    }

    /// <summary>
    /// Сравнивает цвет пикселя с целевым цветом с учетом допустимой погрешности
    /// </summary>
    public static bool CheckPixelColorMatch(Bitmap bmp, int pointX, int pointY, Color targetColor)
    {
        if (pointX < 0 || pointX >= bmp.Width || pointY < 0 || pointY >= bmp.Height)
            return false;

        Color pixel = bmp.GetPixel(pointX, pointY);

        return Math.Abs(pixel.R - targetColor.R) <= Tolerance &&
               Math.Abs(pixel.G - targetColor.G) <= Tolerance &&
               Math.Abs(pixel.B - targetColor.B) <= Tolerance;
    }

    /// <summary>
    /// Возвращает сумму модулей разностей RGB каналов между двумя цветами. Максимальное значение 765.
    /// </summary>
    public static int GetColorDifference(Color c1, Color c2)
    {
        return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) + Math.Abs(c1.B - c2.B);
    }

    /// <summary>
    /// Конвертирует Bitmap в OpenCV Mat
    /// </summary>
    public static Mat BitmapToMat(Bitmap bmp)
    {
        return BitmapConverter.ToMat(bmp);
    }

    /// <summary>
    /// Находит Y-координату центра объекта заданного цвета (через HSV фильтр)
    /// </summary>
    public static int GetCenterYByHsv(Mat image, Scalar lowerBound, Scalar upperBound)
    {
        using var hsv = new Mat();
        using var mask = new Mat();

        // Перевод в HSV
        Cv2.CvtColor(image, hsv, ColorConversionCodes.BGR2HSV);

        // Применение маски
        Cv2.InRange(hsv, lowerBound, upperBound, mask);

        // Находим контуры для поиска центра масс
        Cv2.FindContours(mask, out var contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        if (contours.Length == 0) return -1; // Не найдено

        // Берем самый крупный контур (отсев шумов)
        var largestContour = contours.OrderByDescending(c => Cv2.ContourArea(c)).First();

        var moments = Cv2.Moments(largestContour);
        if (moments.M00 == 0) return -1; // Предотвращение деления на ноль

        // Вычисляем координату Y центра
        int cy = (int)(moments.M01 / moments.M00);
        return cy;
    }

    /// <summary>
    /// Ищет эталонное изображение (template) на основном экране. 
    /// Возвращает координаты левого верхнего угла совпадения или Point(-1, -1), если совпадение хуже порога.
    /// </summary>
    public static SysPoint FindTemplate(Mat screenMat, Mat templateMat, double threshold = 0.8)
    {
        using var result = new Mat();
        
        // Выполняем поиск шаблона (метод сравнения по коэффициенту корреляции)
        Cv2.MatchTemplate(screenMat, templateMat, result, TemplateMatchModes.CCoeffNormed);

        // Ищем лучшее совпадение
        Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out CvPoint maxLoc);

        if (maxVal >= threshold)
        {
            return new SysPoint(maxLoc.X, maxLoc.Y);
        }

        return new SysPoint(-1, -1);
    }
}
