namespace Minesweeper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            nouvellePartieToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            debutantToolStripMenuItem = new ToolStripMenuItem();
            intermediaireToolStripMenuItem = new ToolStripMenuItem();
            expertToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            quitterToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            aProposToolStripMenuItem = new ToolStripMenuItem();
            GameBoardView = new Minesweeper.Controls.BoardView();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(776, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nouvellePartieToolStripMenuItem, toolStripSeparator1, debutantToolStripMenuItem, intermediaireToolStripMenuItem, expertToolStripMenuItem, toolStripSeparator2, quitterToolStripMenuItem });
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            fichierToolStripMenuItem.Size = new Size(54, 20);
            fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouvellePartieToolStripMenuItem
            // 
            nouvellePartieToolStripMenuItem.Name = "nouvellePartieToolStripMenuItem";
            nouvellePartieToolStripMenuItem.Size = new Size(169, 22);
            nouvellePartieToolStripMenuItem.Text = "Nouvelle partie";
            nouvellePartieToolStripMenuItem.Click += nouvellePartieToolStripMenuItem_Click;
            nouvellePartieToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((Keys.F2)));
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(166, 6);
            // 
            // debutantToolStripMenuItem
            // 
            debutantToolStripMenuItem.Name = "debutantToolStripMenuItem";
            debutantToolStripMenuItem.Size = new Size(169, 22);
            debutantToolStripMenuItem.Text = "Débutant";
            debutantToolStripMenuItem.Click += debutantToolStripMenuItem_Click;
            // 
            // intermediaireToolStripMenuItem
            // 
            intermediaireToolStripMenuItem.Name = "intermediaireToolStripMenuItem";
            intermediaireToolStripMenuItem.Size = new Size(169, 22);
            intermediaireToolStripMenuItem.Text = "Intermédiaire";
            intermediaireToolStripMenuItem.Click += intermediaireToolStripMenuItem_Click;
            // 
            // expertToolStripMenuItem
            // 
            expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            expertToolStripMenuItem.Size = new Size(169, 22);
            expertToolStripMenuItem.Text = "Expert";
            expertToolStripMenuItem.Click += expertToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(166, 6);
            // 
            // quitterToolStripMenuItem
            // 
            quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            quitterToolStripMenuItem.Size = new Size(169, 22);
            quitterToolStripMenuItem.Text = "Quitter";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { aProposToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(24, 20);
            toolStripMenuItem1.Text = "?";
            // 
            // aProposToolStripMenuItem
            // 
            aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            aProposToolStripMenuItem.Size = new Size(131, 22);
            aProposToolStripMenuItem.Text = "A propos...";
            // 
            // GameBoardView
            // 
            GameBoardView.Location = new Point(38, 27);
            GameBoardView.Name = "GameBoardView";
            GameBoardView.Size = new Size(123, 87);
            GameBoardView.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 455);
            Controls.Add(GameBoardView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem nouvellePartieToolStripMenuItem;
        private ToolStripMenuItem debutantToolStripMenuItem;
        private ToolStripMenuItem intermediaireToolStripMenuItem;
        private ToolStripMenuItem expertToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem aProposToolStripMenuItem;
        private Controls.BoardView GameBoardView;
    }
}
