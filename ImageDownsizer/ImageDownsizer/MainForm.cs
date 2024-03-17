using System.Diagnostics;

namespace ImageDownsizer
{
    public partial class MainForm : Form
    {
        double downsizingFactor = 0.0;
        string selectedImagePath = string.Empty;
        Bitmap selectedImage;
        Bitmap downsizedImage;

        Stopwatch stopwatch = new Stopwatch();

        public MainForm()
        {
            InitializeComponent();
        }

        //copied from - https://ourcodeworld.com/articles/read/507/how-to-allow-only-numbers-inside-a-textbox-in-winforms-c-sharp
        private void tbDownsizingFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnDownsizeNonParallel_Click(object sender, EventArgs e)
        {
            if (!GetDownsizingFactorFromTextBox())
                return;

            if (pbSelectedImage.Image == null)
            {
                MessageBox.Show("Select an image to downsize!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Thread downsizingThread = new Thread()
            stopwatch.Restart();
            downsizedImage = BilinearInterpolationNonParallelDownsizer.DownsizeImage(selectedImage, downsizingFactor);
            stopwatch.Stop();

            lblNonParallelTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
            pbSelectedImage.Image = downsizedImage;

        }

        private void btnDownsizeParallel_Click(object sender, EventArgs e)
        {
            if (!GetDownsizingFactorFromTextBox())
                return;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            SelectImageFromPC();
        }

        private void SelectImageFromPC()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;//probably redundant

                selectedImage = new Bitmap(selectedImagePath);
                pbSelectedImage.Image = selectedImage;
            }

        }


        public bool GetDownsizingFactorFromTextBox()
        {
            if (tbDownsizingFactorInput.Text.Equals(string.Empty) || tbDownsizingFactorInput.Text.Equals("."))
            {
                MessageBox.Show("Enter a real number value in the text box!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            downsizingFactor = double.Parse(tbDownsizingFactorInput.Text) / 100.0;

            if (downsizingFactor == 0)
            {
                MessageBox.Show("Downsizing factor cannot be 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        private void btnSaveDownsizedImage_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                downsizedImage.Save(saveFileDialog.FileName);
            }
        }
    }
}
