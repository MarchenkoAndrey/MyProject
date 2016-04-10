namespace Resettlement
{
    partial class UserInterface
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void InitializeComponent()
        {
            this.greedy_btn = new System.Windows.Forms.Button();
            this.fullSearch_btn = new System.Windows.Forms.Button();
            this.labelOne = new System.Windows.Forms.Label();
            this.squareOne_input = new System.Windows.Forms.TextBox();
            this.labelTwo = new System.Windows.Forms.Label();
            this.squareTwo_input = new System.Windows.Forms.TextBox();
            this.labelCountFloor = new System.Windows.Forms.Label();
            this.lossesTwo_label = new System.Windows.Forms.Label();
            this.lossesOne_label = new System.Windows.Forms.Label();
            this.realizat_label = new System.Windows.Forms.Label();
            this.resultFullSearch_label = new System.Windows.Forms.Label();
            this.resultGreedy_label = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valueQ = new System.Windows.Forms.TextBox();
            this.valueG = new System.Windows.Forms.TextBox();
            this.valueC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // greedy_btn
            // 
            this.greedy_btn.Location = new System.Drawing.Point(286, 134);
            this.greedy_btn.Name = "greedy_btn";
            this.greedy_btn.Size = new System.Drawing.Size(119, 23);
            this.greedy_btn.TabIndex = 0;
            this.greedy_btn.Text = "Heuristic Algorithm";
            this.greedy_btn.UseVisualStyleBackColor = true;
            this.greedy_btn.Click += new System.EventHandler(this.greedy_btn_Click);
            // 
            // fullSearch_btn
            // 
            this.fullSearch_btn.Location = new System.Drawing.Point(422, 134);
            this.fullSearch_btn.Name = "fullSearch_btn";
            this.fullSearch_btn.Size = new System.Drawing.Size(141, 23);
            this.fullSearch_btn.TabIndex = 1;
            this.fullSearch_btn.Text = "Comprehensive Search";
            this.fullSearch_btn.UseVisualStyleBackColor = true;
            this.fullSearch_btn.Click += new System.EventHandler(this.fullSearch_btn_Click);
            // 
            // labelOne
            // 
            this.labelOne.AutoSize = true;
            this.labelOne.Location = new System.Drawing.Point(26, 40);
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(252, 26);
            this.labelOne.TabIndex = 2;
            this.labelOne.Text = "Enter the squares of the rectangles a(i) with a space\r\n or specify a file name";
            // 
            // squareOne_input
            // 
            this.squareOne_input.Location = new System.Drawing.Point(286, 42);
            this.squareOne_input.Name = "squareOne_input";
            this.squareOne_input.Size = new System.Drawing.Size(277, 20);
            this.squareOne_input.TabIndex = 3;
            // 
            // labelTwo
            // 
            this.labelTwo.AutoSize = true;
            this.labelTwo.Location = new System.Drawing.Point(26, 79);
            this.labelTwo.Name = "labelTwo";
            this.labelTwo.Size = new System.Drawing.Size(252, 26);
            this.labelTwo.TabIndex = 4;
            this.labelTwo.Text = "Enter the squares of the rectangles b(i) with a space\r\n or specify a file name";
            // 
            // squareTwo_input
            // 
            this.squareTwo_input.Location = new System.Drawing.Point(286, 80);
            this.squareTwo_input.Name = "squareTwo_input";
            this.squareTwo_input.Size = new System.Drawing.Size(277, 20);
            this.squareTwo_input.TabIndex = 5;
            // 
            // labelCountFloor
            // 
            this.labelCountFloor.AutoSize = true;
            this.labelCountFloor.Location = new System.Drawing.Point(26, 112);
            this.labelCountFloor.Name = "labelCountFloor";
            this.labelCountFloor.Size = new System.Drawing.Size(0, 13);
            this.labelCountFloor.TabIndex = 6;
            // 
            // lossesTwo_label
            // 
            this.lossesTwo_label.AutoSize = true;
            this.lossesTwo_label.Location = new System.Drawing.Point(23, 229);
            this.lossesTwo_label.Name = "lossesTwo_label";
            this.lossesTwo_label.Size = new System.Drawing.Size(0, 13);
            this.lossesTwo_label.TabIndex = 9;
            // 
            // lossesOne_label
            // 
            this.lossesOne_label.AutoSize = true;
            this.lossesOne_label.Location = new System.Drawing.Point(283, 177);
            this.lossesOne_label.Name = "lossesOne_label";
            this.lossesOne_label.Size = new System.Drawing.Size(0, 13);
            this.lossesOne_label.TabIndex = 8;
            // 
            // realizat_label
            // 
            this.realizat_label.AutoSize = true;
            this.realizat_label.Location = new System.Drawing.Point(23, 182);
            this.realizat_label.Name = "realizat_label";
            this.realizat_label.Size = new System.Drawing.Size(0, 13);
            this.realizat_label.TabIndex = 10;
            // 
            // resultFullSearch_label
            // 
            this.resultFullSearch_label.AutoSize = true;
            this.resultFullSearch_label.Location = new System.Drawing.Point(23, 215);
            this.resultFullSearch_label.Name = "resultFullSearch_label";
            this.resultFullSearch_label.Size = new System.Drawing.Size(0, 13);
            this.resultFullSearch_label.TabIndex = 20;
            // 
            // resultGreedy_label
            // 
            this.resultGreedy_label.AutoSize = true;
            this.resultGreedy_label.Location = new System.Drawing.Point(604, 152);
            this.resultGreedy_label.Name = "resultGreedy_label";
            this.resultGreedy_label.Size = new System.Drawing.Size(0, 13);
            this.resultGreedy_label.TabIndex = 21;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(29, 128);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "One";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(29, 150);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(46, 17);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Two";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(118, 128);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(53, 17);
            this.radioButton3.TabIndex = 30;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Three";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(118, 152);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(55, 17);
            this.radioButton4.TabIndex = 31;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Four";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Select the number of floors";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enter the value of the wall thickness q";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Enter the value of length of the constant rectangle g";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Enter the value of width of the rectangles c";
            // 
            // valueQ
            // 
            this.valueQ.Location = new System.Drawing.Point(900, 45);
            this.valueQ.Name = "valueQ";
            this.valueQ.Size = new System.Drawing.Size(40, 20);
            this.valueQ.TabIndex = 25;
            // 
            // valueG
            // 
            this.valueG.Location = new System.Drawing.Point(900, 72);
            this.valueG.Name = "valueG";
            this.valueG.Size = new System.Drawing.Size(40, 20);
            this.valueG.TabIndex = 26;
            // 
            // valueC
            // 
            this.valueC.Location = new System.Drawing.Point(900, 104);
            this.valueC.Name = "valueC";
            this.valueC.Size = new System.Drawing.Size(40, 20);
            this.valueC.TabIndex = 27;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 556);
            this.Controls.Add(this.valueC);
            this.Controls.Add(this.valueG);
            this.Controls.Add(this.valueQ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.resultGreedy_label);
            this.Controls.Add(this.resultFullSearch_label);
            this.Controls.Add(this.realizat_label);
            this.Controls.Add(this.lossesTwo_label);
            this.Controls.Add(this.lossesOne_label);
            this.Controls.Add(this.labelCountFloor);
            this.Controls.Add(this.squareTwo_input);
            this.Controls.Add(this.labelTwo);
            this.Controls.Add(this.squareOne_input);
            this.Controls.Add(this.labelOne);
            this.Controls.Add(this.fullSearch_btn);
            this.Controls.Add(this.greedy_btn);
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button greedy_btn;
        private System.Windows.Forms.Button fullSearch_btn;
        private System.Windows.Forms.Label labelOne;
        private System.Windows.Forms.TextBox squareOne_input;
        private System.Windows.Forms.Label labelTwo;
        private System.Windows.Forms.TextBox squareTwo_input;
        private System.Windows.Forms.Label labelCountFloor;
        private System.Windows.Forms.Label lossesTwo_label;
        private System.Windows.Forms.Label lossesOne_label;
        private System.Windows.Forms.Label realizat_label;
        protected System.Windows.Forms.Label resultFullSearch_label;
        protected System.Windows.Forms.Label resultGreedy_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox valueQ;
        private System.Windows.Forms.TextBox valueG;
        private System.Windows.Forms.TextBox valueC;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label4;
    }
}