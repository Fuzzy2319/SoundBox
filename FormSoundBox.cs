using System.Data;
using WMPLib;

namespace SoundBox
{
    public partial class FormSoundBox : Form
    {
        private List<WindowsMediaPlayer> theSounds;
        private List<Button> theButtons;

        public FormSoundBox()
        {
            this.theSounds = new List<WindowsMediaPlayer>();
            this.theButtons = new List<Button>();
            InitializeComponent();
        }

        private void CreateSoundPlayer(string soundPath)
        {
            WindowsMediaPlayer aSoundPlayer = new WindowsMediaPlayer();
            aSoundPlayer.URL = soundPath;
            aSoundPlayer.controls.stop();
            this.theSounds.Add(aSoundPlayer);
        }
        private void CreateButton(int ind)
        {
            Button aButton = new Button();
            aButton.Name = "btnSound" + ind;
            aButton.Location = new Point(200 * ind + 100, 50);
            aButton.Size = new Size(200, 50);
            aButton.TabIndex = ind;
            aButton.Text = Path.GetFileNameWithoutExtension(theSounds[ind].URL);
            aButton.UseVisualStyleBackColor = true;
            aButton.Click += new EventHandler(btnSound_Click);
            this.theButtons.Add(aButton);
        }
        private void btnSound_Click(object sender, EventArgs e)
        {
            try
            {
                bool isPlaying = false;
                int ind = -1;
                while (!isPlaying && ind < (theSounds.Count - 1))
                {
                    ind += 1;
                    isPlaying = theSounds[ind].status.StartsWith("Lecture");
                }
                if (!isPlaying)
                {
                    theSounds[this.flpSounds.Controls.IndexOf((Control)sender)].controls.play();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FormSoundBox_Shown(object sender, EventArgs e)
        {
            string mediaFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SoundBox\Media\";
            List<string> allowedExtensions = new List<string>();
            allowedExtensions.AddRange(new[] { ".aac", ".aif", ".aup", ".cda", ".flac", ".m3u", ".m4a", ".mid", ".midi", ".mp3", ".mpa", ".oga", ".ogg", ".ra", ".ram", ".wav", ".wma" });
            if (!Directory.Exists(mediaFolder))
            {
                Directory.CreateDirectory(mediaFolder);
            }
            List<string> soundFiles = Directory.EnumerateFiles(mediaFolder).Where(aFile => allowedExtensions.Any(aFile.ToLower().EndsWith)).ToList();
            if (soundFiles.Count == 0)
            {
                MessageBox.Show("Aucun son trouvé, vous pouvez en ajouter dans le dossier " + mediaFolder);
                Environment.Exit(-1);
            }
            else
            {
                string aSoundFile;
                for (int ind = 0; ind < soundFiles.Count; ind += 1)
                {
                    aSoundFile = soundFiles[ind];
                    CreateSoundPlayer(aSoundFile);
                    CreateButton(ind);
                    this.flpSounds.Controls.Add(theButtons[ind]);
                }
            }
        }
    }
}
