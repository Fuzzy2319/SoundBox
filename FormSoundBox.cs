using WMPLib;

namespace SoundBox
{
    public partial class FormSoundBox : Form
    {
        private readonly WindowsMediaPlayer player;
        private readonly List<Button> buttons;
        private readonly List<Uri> sounds;

        public FormSoundBox()
        {
            this.player = new WindowsMediaPlayer();
            this.buttons = new List<Button>();
            this.sounds = new List<Uri>();
            this.InitializeComponent();
        }
        private void CreateButton(int ind)
        {
            Button button = new Button();
            button.Name = $"btnSound{ind}";
            button.Location = new Point(200 * ind + 100, 50);
            button.Size = new Size(200, 50);
            button.TabIndex = ind;
            button.Text = Path.GetFileNameWithoutExtension(this.sounds[ind].ToString());
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler(this.BtnSound_Click);
            this.buttons.Add(button);
        }

        private void BtnSound_Click(object? sender, EventArgs? e)
        {
            this.player.URL = this.sounds[this.flpSounds.Controls.IndexOf((Control?)sender)].ToString();
            this.player.controls.play();
        }

        private void FormSoundBox_Shown(object sender, EventArgs? e)
        {
            for (int ind = 0; ind < this.sounds.Count; ind += 1)
            {
                this.CreateButton(ind);
                this.flpSounds.Controls.Add(this.buttons[ind]);
            }
        }

        private void FormSoundBox_Load(object sender, EventArgs e)
        {
            string mediaFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + @"\SoundBox\";
            string[] allowedExtensions = new string[] { ".aac", ".aif", ".aup", ".cda", ".flac", ".m3u", ".m4a", ".mid", ".midi", ".mp3", ".mpa", ".oga", ".ogg", ".ra", ".ram", ".wav", ".wma" };
            if (!Directory.Exists(mediaFolder))
            {
                Directory.CreateDirectory(mediaFolder);
            };
            Directory.EnumerateFiles(mediaFolder)
            .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
            .ToList()
            .ForEach(file =>
            {
                this.sounds.Add(new Uri(file));
            });
            if (this.sounds.Count == 0)
            {
                MessageBox.Show($"Aucun son trouvé, vous pouvez en ajouter dans le dossier {mediaFolder}");
                Environment.Exit(-1);
            }
        }
    }
}
