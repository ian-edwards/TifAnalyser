using System.Drawing;
using System.Drawing.Imaging;

float[][] data = Array.Empty<float[]>();
{
    Bitmap image = LoadImage("data.tif");
    data = PixelHeights(image);
}
Analyse(data);

static void Analyse(float[][] data)
{
    // todo
}

static float[][] PixelHeights(Bitmap image)
{
    var data = new float[image.Height][];
    for (int y = 0; y< image.Height; y++)
    {
        var row = new float[image.Width];
        for (int x = 0; x < image.Width; x++)
        {
            Color c = image.GetPixel(x, y);
            row[x] = PixelHeight(c.R, c.G, c.B, c.A);
        }
        data[y] = row;
    }
    return data;
}


static Bitmap LoadImage(string filename)
{
    Image tif = Image.FromFile(filename);
    tif.SelectActiveFrame(FrameDimension.Page, 0);
    return new Bitmap(tif);
}

static float PixelHeight(byte red, byte green, byte blue, byte alpha)
{
    return red + green + blue + alpha; // todo
}