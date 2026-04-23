using Diplom_Maksim.Properties;
using System.Collections;
using System.Data;
using System.Globalization;

namespace Diplom_Maksim
{
    public partial class Zasttavka : Form
    {
        public Zasttavka()
        {
            InitializeComponent();
            var images = Resources.ResourceManager
    .GetResourceSet(CultureInfo.CurrentCulture, true, true)
    .Cast<DictionaryEntry>()
    .Where(x => x.Value.GetType() == typeof(Bitmap))
    .Select(x => new { Name = x.Key.ToString(), Image = (Bitmap)x.Value })
    .ToList();

            // Получаем случайное изображение
            var rnd = new Random().Next(images.Count);
            var image = images[rnd].Image;
            pictureBox1.Image = image;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Opacity += 0.1d;
        }
    }
}
