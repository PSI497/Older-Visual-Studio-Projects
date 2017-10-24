namespace Vocabulary
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.new_wordname_tb = new System.Windows.Forms.TextBox();
            this.LV_words = new System.Windows.Forms.ListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.word = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.translation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.new_transname_tb = new System.Windows.Forms.TextBox();
            this.LV_vocab = new System.Windows.Forms.ListView();
            this.Vocabularys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.create_new_word = new System.Windows.Forms.Button();
            this.create_new_vocab = new System.Windows.Forms.Button();
            this.new_vocabname_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.delete_worditen = new System.Windows.Forms.Button();
            this.delete_vocab = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.databasepage = new System.Windows.Forms.TabPage();
            this.gamepage = new System.Windows.Forms.TabPage();
            this.label_definition = new System.Windows.Forms.TextBox();
            this.label_lastresult = new System.Windows.Forms.TextBox();
            this.checkBox_Swap = new System.Windows.Forms.CheckBox();
            this.radioButton_Sequence = new System.Windows.Forms.RadioButton();
            this.radioButton_RSRep = new System.Windows.Forms.RadioButton();
            this.radioButton_RSeq = new System.Windows.Forms.RadioButton();
            this.radioButton_random = new System.Windows.Forms.RadioButton();
            this.button_answer = new System.Windows.Forms.Button();
            this.button_startnewgame = new System.Windows.Forms.Button();
            this.label_score = new System.Windows.Forms.Label();
            this.tb_answer = new System.Windows.Forms.TextBox();
            this.label_question = new System.Windows.Forms.Label();
            this.button_editworditem = new System.Windows.Forms.Button();
            this.tb_editword = new System.Windows.Forms.TextBox();
            this.tb_edittrans = new System.Windows.Forms.TextBox();
            this.tb_new_definition = new System.Windows.Forms.TextBox();
            this.tb_edit_definition = new System.Windows.Forms.TextBox();
            this.label_display1 = new System.Windows.Forms.Label();
            this.label_display2 = new System.Windows.Forms.Label();
            this.label_display3 = new System.Windows.Forms.Label();
            this.label_display4 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.databasepage.SuspendLayout();
            this.gamepage.SuspendLayout();
            this.SuspendLayout();
            // 
            // new_wordname_tb
            // 
            this.new_wordname_tb.Location = new System.Drawing.Point(234, 362);
            this.new_wordname_tb.Name = "new_wordname_tb";
            this.new_wordname_tb.Size = new System.Drawing.Size(206, 20);
            this.new_wordname_tb.TabIndex = 0;
            this.new_wordname_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.new_wordname_tb_KeyDown);
            // 
            // LV_words
            // 
            this.LV_words.BackColor = System.Drawing.Color.LimeGreen;
            this.LV_words.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.word,
            this.translation});
            this.LV_words.FullRowSelect = true;
            this.LV_words.GridLines = true;
            this.LV_words.HideSelection = false;
            this.LV_words.Location = new System.Drawing.Point(0, 0);
            this.LV_words.Name = "LV_words";
            this.LV_words.Size = new System.Drawing.Size(551, 324);
            this.LV_words.TabIndex = 1;
            this.LV_words.UseCompatibleStateImageBehavior = false;
            this.LV_words.View = System.Windows.Forms.View.Details;
            this.LV_words.SelectedIndexChanged += new System.EventHandler(this.LV_words_SelectedIndexChanged);
            // 
            // index
            // 
            this.index.Text = "Index";
            this.index.Width = 42;
            // 
            // word
            // 
            this.word.Text = "Word";
            this.word.Width = 238;
            // 
            // translation
            // 
            this.translation.Text = "Translation";
            this.translation.Width = 266;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Word:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Translation:";
            // 
            // new_transname_tb
            // 
            this.new_transname_tb.Location = new System.Drawing.Point(234, 386);
            this.new_transname_tb.Name = "new_transname_tb";
            this.new_transname_tb.Size = new System.Drawing.Size(206, 20);
            this.new_transname_tb.TabIndex = 4;
            this.new_transname_tb.TextChanged += new System.EventHandler(this.new_transname_tb_TextChanged);
            this.new_transname_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.new_transname_tb_KeyDown);
            // 
            // LV_vocab
            // 
            this.LV_vocab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LV_vocab.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Vocabularys});
            this.LV_vocab.FullRowSelect = true;
            this.LV_vocab.HideSelection = false;
            this.LV_vocab.Location = new System.Drawing.Point(12, 7);
            this.LV_vocab.MultiSelect = false;
            this.LV_vocab.Name = "LV_vocab";
            this.LV_vocab.Size = new System.Drawing.Size(149, 346);
            this.LV_vocab.TabIndex = 5;
            this.LV_vocab.UseCompatibleStateImageBehavior = false;
            this.LV_vocab.View = System.Windows.Forms.View.Details;
            this.LV_vocab.SelectedIndexChanged += new System.EventHandler(this.LV_vocab_SelectedIndexChanged);
            // 
            // Vocabularys
            // 
            this.Vocabularys.Text = "Vocabularys";
            this.Vocabularys.Width = 144;
            // 
            // create_new_word
            // 
            this.create_new_word.Location = new System.Drawing.Point(282, 528);
            this.create_new_word.Name = "create_new_word";
            this.create_new_word.Size = new System.Drawing.Size(77, 23);
            this.create_new_word.TabIndex = 6;
            this.create_new_word.Text = "Add Word";
            this.create_new_word.UseVisualStyleBackColor = true;
            this.create_new_word.Click += new System.EventHandler(this.create_new_word_Click);
            // 
            // create_new_vocab
            // 
            this.create_new_vocab.Location = new System.Drawing.Point(66, 383);
            this.create_new_vocab.Name = "create_new_vocab";
            this.create_new_vocab.Size = new System.Drawing.Size(95, 25);
            this.create_new_vocab.TabIndex = 7;
            this.create_new_vocab.Text = "Create new vocab";
            this.create_new_vocab.UseVisualStyleBackColor = true;
            this.create_new_vocab.Click += new System.EventHandler(this.create_new_vocab_Click);
            // 
            // new_vocabname_tb
            // 
            this.new_vocabname_tb.Location = new System.Drawing.Point(85, 359);
            this.new_vocabname_tb.Name = "new_vocabname_tb";
            this.new_vocabname_tb.Size = new System.Drawing.Size(77, 20);
            this.new_vocabname_tb.TabIndex = 8;
            this.new_vocabname_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.new_vocabname_tb_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vocab name:";
            // 
            // delete_worditen
            // 
            this.delete_worditen.Location = new System.Drawing.Point(365, 528);
            this.delete_worditen.Name = "delete_worditen";
            this.delete_worditen.Size = new System.Drawing.Size(75, 23);
            this.delete_worditen.TabIndex = 10;
            this.delete_worditen.Text = "Delete word";
            this.delete_worditen.UseVisualStyleBackColor = true;
            this.delete_worditen.Click += new System.EventHandler(this.delete_worditen_Click);
            // 
            // delete_vocab
            // 
            this.delete_vocab.Location = new System.Drawing.Point(12, 383);
            this.delete_vocab.Name = "delete_vocab";
            this.delete_vocab.Size = new System.Drawing.Size(48, 25);
            this.delete_vocab.TabIndex = 11;
            this.delete_vocab.Text = "Delete";
            this.delete_vocab.UseVisualStyleBackColor = true;
            this.delete_vocab.Click += new System.EventHandler(this.delete_vocab_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.databasepage);
            this.tabControl.Controls.Add(this.gamepage);
            this.tabControl.Location = new System.Drawing.Point(167, 7);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(555, 346);
            this.tabControl.TabIndex = 13;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // databasepage
            // 
            this.databasepage.Controls.Add(this.LV_words);
            this.databasepage.Location = new System.Drawing.Point(4, 22);
            this.databasepage.Name = "databasepage";
            this.databasepage.Padding = new System.Windows.Forms.Padding(3);
            this.databasepage.Size = new System.Drawing.Size(547, 320);
            this.databasepage.TabIndex = 0;
            this.databasepage.Text = "Words";
            this.databasepage.UseVisualStyleBackColor = true;
            // 
            // gamepage
            // 
            this.gamepage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.gamepage.Controls.Add(this.label_definition);
            this.gamepage.Controls.Add(this.label_lastresult);
            this.gamepage.Controls.Add(this.checkBox_Swap);
            this.gamepage.Controls.Add(this.radioButton_Sequence);
            this.gamepage.Controls.Add(this.radioButton_RSRep);
            this.gamepage.Controls.Add(this.radioButton_RSeq);
            this.gamepage.Controls.Add(this.radioButton_random);
            this.gamepage.Controls.Add(this.button_answer);
            this.gamepage.Controls.Add(this.button_startnewgame);
            this.gamepage.Controls.Add(this.label_score);
            this.gamepage.Controls.Add(this.tb_answer);
            this.gamepage.Controls.Add(this.label_question);
            this.gamepage.Location = new System.Drawing.Point(4, 22);
            this.gamepage.Name = "gamepage";
            this.gamepage.Padding = new System.Windows.Forms.Padding(3);
            this.gamepage.Size = new System.Drawing.Size(547, 320);
            this.gamepage.TabIndex = 1;
            this.gamepage.Text = "Game";
            // 
            // label_definition
            // 
            this.label_definition.BackColor = System.Drawing.SystemColors.Info;
            this.label_definition.Location = new System.Drawing.Point(9, 32);
            this.label_definition.Multiline = true;
            this.label_definition.Name = "label_definition";
            this.label_definition.ReadOnly = true;
            this.label_definition.Size = new System.Drawing.Size(532, 105);
            this.label_definition.TabIndex = 27;
            // 
            // label_lastresult
            // 
            this.label_lastresult.BackColor = System.Drawing.Color.Wheat;
            this.label_lastresult.Location = new System.Drawing.Point(8, 169);
            this.label_lastresult.Multiline = true;
            this.label_lastresult.Name = "label_lastresult";
            this.label_lastresult.ReadOnly = true;
            this.label_lastresult.Size = new System.Drawing.Size(533, 79);
            this.label_lastresult.TabIndex = 26;
            // 
            // checkBox_Swap
            // 
            this.checkBox_Swap.AutoSize = true;
            this.checkBox_Swap.Location = new System.Drawing.Point(469, 285);
            this.checkBox_Swap.Name = "checkBox_Swap";
            this.checkBox_Swap.Size = new System.Drawing.Size(53, 17);
            this.checkBox_Swap.TabIndex = 24;
            this.checkBox_Swap.Text = "Swap";
            this.checkBox_Swap.UseVisualStyleBackColor = true;
            // 
            // radioButton_Sequence
            // 
            this.radioButton_Sequence.AutoSize = true;
            this.radioButton_Sequence.Checked = true;
            this.radioButton_Sequence.Location = new System.Drawing.Point(121, 284);
            this.radioButton_Sequence.Name = "radioButton_Sequence";
            this.radioButton_Sequence.Size = new System.Drawing.Size(74, 17);
            this.radioButton_Sequence.TabIndex = 23;
            this.radioButton_Sequence.TabStop = true;
            this.radioButton_Sequence.Text = "Sequence";
            this.radioButton_Sequence.UseVisualStyleBackColor = true;
            this.radioButton_Sequence.CheckedChanged += new System.EventHandler(this.radioButton_Sequence_CheckedChanged);
            // 
            // radioButton_RSRep
            // 
            this.radioButton_RSRep.AutoSize = true;
            this.radioButton_RSRep.Location = new System.Drawing.Point(321, 284);
            this.radioButton_RSRep.Name = "radioButton_RSRep";
            this.radioButton_RSRep.Size = new System.Drawing.Size(142, 17);
            this.radioButton_RSRep.TabIndex = 22;
            this.radioButton_RSRep.TabStop = true;
            this.radioButton_RSRep.Text = "Random Seq Repetative";
            this.radioButton_RSRep.UseVisualStyleBackColor = true;
            this.radioButton_RSRep.CheckedChanged += new System.EventHandler(this.radioButton_RSRep_CheckedChanged);
            // 
            // radioButton_RSeq
            // 
            this.radioButton_RSeq.AutoSize = true;
            this.radioButton_RSeq.Location = new System.Drawing.Point(198, 284);
            this.radioButton_RSeq.Name = "radioButton_RSeq";
            this.radioButton_RSeq.Size = new System.Drawing.Size(117, 17);
            this.radioButton_RSeq.TabIndex = 21;
            this.radioButton_RSeq.TabStop = true;
            this.radioButton_RSeq.Text = "Random Sequence";
            this.radioButton_RSeq.UseVisualStyleBackColor = true;
            this.radioButton_RSeq.CheckedChanged += new System.EventHandler(this.radioButton_RSeq_CheckedChanged);
            // 
            // radioButton_random
            // 
            this.radioButton_random.AutoSize = true;
            this.radioButton_random.Location = new System.Drawing.Point(50, 284);
            this.radioButton_random.Name = "radioButton_random";
            this.radioButton_random.Size = new System.Drawing.Size(65, 17);
            this.radioButton_random.TabIndex = 20;
            this.radioButton_random.TabStop = true;
            this.radioButton_random.Text = "Random";
            this.radioButton_random.UseVisualStyleBackColor = true;
            this.radioButton_random.CheckedChanged += new System.EventHandler(this.radioButton_random_CheckedChanged);
            // 
            // button_answer
            // 
            this.button_answer.Location = new System.Drawing.Point(178, 254);
            this.button_answer.Name = "button_answer";
            this.button_answer.Size = new System.Drawing.Size(91, 24);
            this.button_answer.TabIndex = 19;
            this.button_answer.Text = "Answer";
            this.button_answer.UseVisualStyleBackColor = true;
            this.button_answer.Click += new System.EventHandler(this.button_answer_Click);
            // 
            // button_startnewgame
            // 
            this.button_startnewgame.Location = new System.Drawing.Point(275, 255);
            this.button_startnewgame.Name = "button_startnewgame";
            this.button_startnewgame.Size = new System.Drawing.Size(91, 23);
            this.button_startnewgame.TabIndex = 18;
            this.button_startnewgame.Text = "Start new game";
            this.button_startnewgame.UseVisualStyleBackColor = true;
            this.button_startnewgame.Click += new System.EventHandler(this.button_startnewgame_Click);
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_score.Location = new System.Drawing.Point(125, 10);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(0, 13);
            this.label_score.TabIndex = 15;
            // 
            // tb_answer
            // 
            this.tb_answer.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tb_answer.Location = new System.Drawing.Point(185, 143);
            this.tb_answer.Name = "tb_answer";
            this.tb_answer.Size = new System.Drawing.Size(187, 20);
            this.tb_answer.TabIndex = 14;
            this.tb_answer.TextChanged += new System.EventHandler(this.tb_answer_TextChanged);
            this.tb_answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_answer_KeyDown);
            // 
            // label_question
            // 
            this.label_question.AutoSize = true;
            this.label_question.Font = new System.Drawing.Font("Impact", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_question.Location = new System.Drawing.Point(173, 3);
            this.label_question.Name = "label_question";
            this.label_question.Size = new System.Drawing.Size(58, 26);
            this.label_question.TabIndex = 13;
            this.label_question.Text = "Word";
            // 
            // button_editworditem
            // 
            this.button_editworditem.Location = new System.Drawing.Point(453, 528);
            this.button_editworditem.Name = "button_editworditem";
            this.button_editworditem.Size = new System.Drawing.Size(106, 23);
            this.button_editworditem.TabIndex = 14;
            this.button_editworditem.Text = "Edit";
            this.button_editworditem.UseVisualStyleBackColor = true;
            this.button_editworditem.Click += new System.EventHandler(this.button_editworditem_Click);
            // 
            // tb_editword
            // 
            this.tb_editword.Location = new System.Drawing.Point(453, 363);
            this.tb_editword.Name = "tb_editword";
            this.tb_editword.ReadOnly = true;
            this.tb_editword.Size = new System.Drawing.Size(269, 20);
            this.tb_editword.TabIndex = 15;
            // 
            // tb_edittrans
            // 
            this.tb_edittrans.Location = new System.Drawing.Point(453, 388);
            this.tb_edittrans.Name = "tb_edittrans";
            this.tb_edittrans.ReadOnly = true;
            this.tb_edittrans.Size = new System.Drawing.Size(269, 20);
            this.tb_edittrans.TabIndex = 16;
            // 
            // tb_new_definition
            // 
            this.tb_new_definition.Location = new System.Drawing.Point(171, 412);
            this.tb_new_definition.Multiline = true;
            this.tb_new_definition.Name = "tb_new_definition";
            this.tb_new_definition.Size = new System.Drawing.Size(269, 109);
            this.tb_new_definition.TabIndex = 21;
            this.tb_new_definition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_new_definition_KeyDown);
            // 
            // tb_edit_definition
            // 
            this.tb_edit_definition.Location = new System.Drawing.Point(453, 412);
            this.tb_edit_definition.Multiline = true;
            this.tb_edit_definition.Name = "tb_edit_definition";
            this.tb_edit_definition.ReadOnly = true;
            this.tb_edit_definition.Size = new System.Drawing.Size(269, 110);
            this.tb_edit_definition.TabIndex = 22;
            // 
            // label_display1
            // 
            this.label_display1.AutoSize = true;
            this.label_display1.Location = new System.Drawing.Point(869, 430);
            this.label_display1.Name = "label_display1";
            this.label_display1.Size = new System.Drawing.Size(35, 13);
            this.label_display1.TabIndex = 17;
            this.label_display1.Text = "label4";
            this.label_display1.Visible = false;
            // 
            // label_display2
            // 
            this.label_display2.AutoSize = true;
            this.label_display2.Location = new System.Drawing.Point(869, 452);
            this.label_display2.Name = "label_display2";
            this.label_display2.Size = new System.Drawing.Size(35, 13);
            this.label_display2.TabIndex = 18;
            this.label_display2.Text = "label5";
            this.label_display2.Visible = false;
            // 
            // label_display3
            // 
            this.label_display3.AutoSize = true;
            this.label_display3.Location = new System.Drawing.Point(869, 475);
            this.label_display3.Name = "label_display3";
            this.label_display3.Size = new System.Drawing.Size(35, 13);
            this.label_display3.TabIndex = 19;
            this.label_display3.Text = "label6";
            this.label_display3.Visible = false;
            // 
            // label_display4
            // 
            this.label_display4.AutoSize = true;
            this.label_display4.Location = new System.Drawing.Point(869, 497);
            this.label_display4.Name = "label_display4";
            this.label_display4.Size = new System.Drawing.Size(35, 13);
            this.label_display4.TabIndex = 20;
            this.label_display4.Text = "label7";
            this.label_display4.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(734, 554);
            this.Controls.Add(this.tb_edit_definition);
            this.Controls.Add(this.tb_new_definition);
            this.Controls.Add(this.label_display4);
            this.Controls.Add(this.label_display3);
            this.Controls.Add(this.label_display2);
            this.Controls.Add(this.label_display1);
            this.Controls.Add(this.tb_edittrans);
            this.Controls.Add(this.tb_editword);
            this.Controls.Add(this.button_editworditem);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.LV_vocab);
            this.Controls.Add(this.create_new_word);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.new_transname_tb);
            this.Controls.Add(this.new_vocabname_tb);
            this.Controls.Add(this.delete_worditen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.new_wordname_tb);
            this.Controls.Add(this.delete_vocab);
            this.Controls.Add(this.create_new_vocab);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Vocabulary v1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.databasepage.ResumeLayout(false);
            this.gamepage.ResumeLayout(false);
            this.gamepage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox new_wordname_tb;
        private System.Windows.Forms.ListView LV_words;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox new_transname_tb;
        private System.Windows.Forms.ListView LV_vocab;
        private System.Windows.Forms.ColumnHeader Vocabularys;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.ColumnHeader word;
        private System.Windows.Forms.ColumnHeader translation;
        private System.Windows.Forms.Button create_new_word;
        private System.Windows.Forms.Button create_new_vocab;
        private System.Windows.Forms.TextBox new_vocabname_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button delete_worditen;
        private System.Windows.Forms.Button delete_vocab;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage databasepage;
        private System.Windows.Forms.TabPage gamepage;
        private System.Windows.Forms.TextBox tb_answer;
        private System.Windows.Forms.Label label_question;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Button button_startnewgame;
        private System.Windows.Forms.Button button_answer;
        private System.Windows.Forms.Button button_editworditem;
        private System.Windows.Forms.TextBox tb_editword;
        private System.Windows.Forms.TextBox tb_edittrans;
        private System.Windows.Forms.RadioButton radioButton_RSRep;
        private System.Windows.Forms.RadioButton radioButton_RSeq;
        private System.Windows.Forms.RadioButton radioButton_random;
        private System.Windows.Forms.RadioButton radioButton_Sequence;
        private System.Windows.Forms.CheckBox checkBox_Swap;
        private System.Windows.Forms.TextBox label_lastresult;
        private System.Windows.Forms.TextBox tb_new_definition;
        private System.Windows.Forms.TextBox tb_edit_definition;
        private System.Windows.Forms.Label label_display1;
        private System.Windows.Forms.Label label_display2;
        private System.Windows.Forms.Label label_display3;
        private System.Windows.Forms.Label label_display4;
        private System.Windows.Forms.TextBox label_definition;
    }
}

