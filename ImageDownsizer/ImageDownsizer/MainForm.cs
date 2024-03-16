namespace ImageDownsizer
{
    public partial class MainForm : Form
    {
        string selectedImagePath = string.Empty;

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

        }

        private void btnDownsizeParallel_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
                SelectImageFromPC();
        }

        private void SelectImageFromPC()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pbSelectedImage.ImageLocation = selectedImagePath;
            }
                
        }
    }
}
