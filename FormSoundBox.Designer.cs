namespace SoundBox
{
    partial class FormSoundBox
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSoundBox));
            this.flpSounds = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpSounds
            // 
            this.flpSounds.AutoScroll = true;
            this.flpSounds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSounds.Location = new System.Drawing.Point(0, 0);
            this.flpSounds.Margin = new System.Windows.Forms.Padding(0);
            this.flpSounds.Name = "flpSounds";
            this.flpSounds.Padding = new System.Windows.Forms.Padding(50, 31, 50, 31);
            this.flpSounds.Size = new System.Drawing.Size(800, 562);
            this.flpSounds.TabIndex = 0;
            // 
            // FormSoundBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.flpSounds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSoundBox";
            this.Text = "SoundBox v1.0";
            this.Shown += new System.EventHandler(this.FormSoundBox_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSounds;
    }
}
