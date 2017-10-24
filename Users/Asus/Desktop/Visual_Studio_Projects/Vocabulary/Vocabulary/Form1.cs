using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
namespace Vocabulary
{
    public partial class Form1 : Form
    {
        private List<Vocab> VocabList = new List<Vocab>();

        private int SVI = -1; //selected vocab index
        private List<int> SWI = new List<int>(); //selected worditem index
        private int SRB = 1; //selected radio button (for the game settings)

        private Game currentGame = new Game();
        public Form1()
        {
            InitializeComponent();
        }

        int GetVocabIndex(string name)
        {
            for (int i = 0; i < VocabList.Count; i++)
            {
                if (VocabList[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Database();
            Load_LV_vocab();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save_Database();
        }
        
        private void Load_LV_vocab()
        {
            LV_vocab.Items.Clear();
            foreach (Vocab v in VocabList)
            {
                LV_vocab.Items.Add(v.name);
            }          
        }
        private void Load_LV_words(int index_of_targetVocab)
        {
            LV_words.Items.Clear();
            if (index_of_targetVocab < 0 | index_of_targetVocab > VocabList.Count - 1) { return; }
            
            foreach (WordItem w in VocabList[index_of_targetVocab].WordList)
            {
                int index = VocabList[index_of_targetVocab].WordList.IndexOf(w) + 1;
                ListViewItem lvi = new ListViewItem(index.ToString());
                lvi.SubItems.Add(w.word);
                lvi.SubItems.Add(w.trans);
                LV_words.Items.Add(lvi);
                
            }   
        }
        private void RefreshScore(string result = "")
        {
            if (result == "Correct answer!")
            {
                label_lastresult.ForeColor = Color.Green;
            }
            else
            {
                label_lastresult.ForeColor = Color.Red;
            }
            label_score.Text = currentGame.score.ToString() + "/" + currentGame.maxscore.ToString();
            label_lastresult.Text = result;
        }

        private void LV_words_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_words.SelectedItems.Count > 0)
            {
                SWI.Clear();
                foreach (ListViewItem lvi in LV_words.SelectedItems)//add all the selected items indexes to the list
                {
                    SWI.Add(lvi.Index);
                }
            }
            else
            {
                SWI.Clear();
            }
        }
        private void LV_vocab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_vocab.SelectedItems.Count > 0)
            {
                SVI = LV_vocab.SelectedItems[0].Index;
                Load_LV_words(SVI);
            }
            else { SVI = -1; }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentGame.running)
            {
                tabControl.SelectedTab = gamepage;
            }
        }

        private void Load_Database()
        {
            try
            {
                StreamReader asd = new StreamReader("vocab.xml");
                string data;
                data = asd.ReadToEnd();
                var sr = new System.IO.StringReader(data);
                var xs = new XmlSerializer(typeof(List<Vocab>));

                VocabList = (List<Vocab>)xs.Deserialize(sr);
                asd.Close();
            }
            catch { }
        }
        private void Save_Database()
        {
            FileStream fs = new FileStream("vocab.xml", FileMode.Create);
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(List<Vocab>));
            s.Serialize(fs, VocabList);
            fs.Close();
        }
        private void CreateNewVocab(string name)
        {
            if (name == "") { return; }
            Vocab v = new Vocab();
            v.name = name;
            VocabList.Add(v);
        }
        private void CreateNewWordItem(string word, string trans, string def, int index_of_targetVocab)
        {
            if (index_of_targetVocab < 0 | index_of_targetVocab > VocabList.Count - 1| word == "" | trans == "") { return; } // if the given values are not eligible for some reason just return(doesnt check if they go  beyond the range !!!!
            WordItem w = new WordItem();
            w.word = word;
            w.trans = trans;

           
            w.definition = def.Replace(trans, "________");
            
            VocabList[index_of_targetVocab].WordList.Add(w);
        }
        private void DeleteWordItem(int index_of_targetVocab, List<int> range_of_targetWordItem)
        {
            if (index_of_targetVocab < 0 | range_of_targetWordItem.Count == 0) { return; } // if the given values are not eligible for some reason just return(doesnt check if they go  beyond the range !!!!)
            foreach (int i in range_of_targetWordItem.Reverse<int>())//the order must be reversed, because if we start with the lower values, the values above will decrease 
            {
                VocabList[index_of_targetVocab].WordList.RemoveAt(i);
            }
        }
        private void EditWordItem(int index_of_targetVocab, int index_of_targetWordItem, string newword, string newtrans, string newdef)
        {
            if (index_of_targetVocab < 0 | index_of_targetWordItem < 0) { return; }
            {
                VocabList[index_of_targetVocab].WordList[index_of_targetWordItem].word = newword;
                VocabList[index_of_targetVocab].WordList[index_of_targetWordItem].trans = newtrans;
                VocabList[index_of_targetVocab].WordList[index_of_targetWordItem].definition = newdef.Replace(newtrans, "______");
            }
        }
        private void DeleteVocab(int index_of_targetVocab)
        {
            if (index_of_targetVocab < 0) { return; }
            VocabList.RemoveAt(index_of_targetVocab);
            
        }

        private void EndGameEvent()
        {
            button_startnewgame.Text = "Start new game";
            currentGame.running = false;
            MessageBox.Show("Game Over!");
        }
        private void Display(int i1, int i2,float i3,float i4)
        {
            label_display1.Text = i1.ToString();
            label_display2.Text = i2.ToString();
            label_display3.Text = i3.ToString();
            label_display4.Text = i4.ToString();
        }
        private void create_new_vocab_Click(object sender, EventArgs e)
        {
            CreateNewVocab(new_vocabname_tb.Text);
            new_vocabname_tb.Clear();
            Load_LV_vocab();
        }
        private void create_new_word_Click(object sender, EventArgs e)
        {
           CreateNewWordItem(new_wordname_tb.Text, new_transname_tb.Text, tb_new_definition.Text, SVI);
           Load_LV_words(SVI);

           new_transname_tb.Clear();
               tb_new_definition.Clear();
           new_wordname_tb.Clear();
        }
        private void delete_worditen_Click(object sender, EventArgs e)
        {           
           DeleteWordItem(SVI, SWI);
           SWI.Clear();
           Load_LV_words(SVI);
        }
        private void delete_vocab_Click(object sender, EventArgs e)
        {
                DeleteVocab(SVI);
                SVI = -1;               
                Load_LV_vocab();
                Load_LV_words(SVI);
        }
        private void button_startnewgame_Click(object sender, EventArgs e)
        {          
            if (currentGame.running)
            {
                button_startnewgame.Text = "Start new game";
                currentGame.running = false;
                RefreshScore();
            }
            else
            {
                if (SVI > -1)
                {                   
                    if (VocabList[SVI].WordList.Count == 0) { return; }
                    currentGame = new Game();
                    currentGame.SetSettings(VocabList[SVI], SRB, checkBox_Swap.Checked);
                    currentGame.running = true;
                    currentGame.EndGameEvent += new Game.EndGameEventHandler(EndGameEvent);
                    currentGame.Display += new Game.DisplayEventHandler(Display);
                    button_startnewgame.Text = "Stop game";
                    label_question.Text = currentGame.GetQestion();
                    label_definition.Text = currentGame.GetDefinitionString();
                }
            }
        }
        private void button_answer_Click(object sender, EventArgs e)
        {
            if (currentGame.running)
            {
                RefreshScore(currentGame.CheckAnswer(tb_answer.Text));
                tb_answer.Clear();
                if (currentGame.running)
                {
                    label_question.Text = currentGame.GetQestion();
                    label_definition.Text = currentGame.GetDefinitionString();
                }
            }
        }

        private void new_wordname_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new_transname_tb.Focus();
            }
        }
        private void new_transname_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_new_definition.Focus();
            }
        }
        private void new_vocabname_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateNewVocab(new_vocabname_tb.Text);
                new_vocabname_tb.Clear();
                Load_LV_vocab();
            }
        }
        private void button_editworditem_Click(object sender, EventArgs e)
        {
           if (tb_edittrans.ReadOnly)
           {
               LV_words.Enabled = false;
               tb_editword.ReadOnly = false;
               tb_edittrans.ReadOnly = false;
               tb_edit_definition.ReadOnly = false;
               tb_editword.Text = VocabList[SVI].WordList[SWI[0]].word;
               tb_edittrans.Text = VocabList[SVI].WordList[SWI[0]].trans;
               tb_edit_definition.Text = VocabList[SVI].WordList[SWI[0]].definition;
           }
           else
           {
               LV_words.Enabled = true;
               EditWordItem(SVI, SWI[0], tb_editword.Text, tb_edittrans.Text, tb_edit_definition.Text);
               Load_LV_words(SVI);
               LV_words.Items[SWI[0]].Selected = true;
               tb_editword.Clear();
               tb_edittrans.Clear();
               tb_editword.ReadOnly = true;
               tb_edittrans.ReadOnly = true;
               tb_edit_definition.ReadOnly = true;
           }
            
        }
        private void tb_answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentGame.running)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RefreshScore(currentGame.CheckAnswer(tb_answer.Text));
                    tb_answer.Clear();
                    if (currentGame.running)
                    {
                        label_question.Text = currentGame.GetQestion();
                        label_definition.Text = currentGame.GetDefinitionString();
                    }
                }
            }
        }
        private void radioButton_Sequence_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Sequence.Checked) { SRB = 1; }
        }
        private void radioButton_random_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_random.Checked) { SRB = 0; }
        }
        private void radioButton_RSeq_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_RSeq.Checked) { SRB = 2; }
        }
        private void radioButton_RSRep_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_RSRep.Checked) { SRB = 3; }
        }

        private void new_transname_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_new_definition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Shift)
            {
                CreateNewWordItem(new_wordname_tb.Text, new_transname_tb.Text, tb_new_definition.Text, SVI);
                Load_LV_words(SVI);

                new_transname_tb.Clear();
                new_wordname_tb.Clear();
                tb_new_definition.Clear();
                new_wordname_tb.Focus();

            }
        }

        private void tb_answer_TextChanged(object sender, EventArgs e)
        {

        }
    }





    public class Game
    {
        public int score = 0;
        public int maxscore = 0;
        List<WordItem> wordList;
        List<int> failAnsw = new List<int>();
        float base_pickFAp = 10;
        int QSelectType = 0; //0: Random, 1: Sequence, 2: Random Sequence, 3: Random Seq Repetative
        int lQ = -1;
        int holder = -1;
        public bool running = false;

        public delegate void EndGameEventHandler();
        public event EndGameEventHandler EndGameEvent;
        public delegate void DisplayEventHandler(int i1, int i2, float i3, float i4);
        public event DisplayEventHandler Display;
        public void SetSettings(Vocab vocab, int Q, bool swap)
        {
            QSelectType = Q;
            wordList = new List<WordItem>();
            if (QSelectType == 0 | QSelectType == 1)
            {
                wordList = vocab.CloneWordList();  
            }
            else if (QSelectType == 2 | QSelectType == 3)
            {
                List<WordItem> templist = vocab.CloneWordList();
                int max = templist.Count;
                Random rnd = new Random();
                for (int i = 0; i < max;i++)
                {                
                    int index = rnd.Next(templist.Count);
                    wordList.Add(templist[index]);
                    templist.RemoveAt(index);
                    templist.Reverse();
                }
            }  
            if (swap)
            {
                foreach (WordItem w in wordList)
                {
                    string temp = w.word;
                    w.word = w.trans;
                    w.trans = temp;
                }
            }
        }
        public string GetQestion()
        {
            string word = "";
            if (QSelectType == 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(wordList.Count);
                lQ = i;
                word = wordList[i].word;
            }
            if (QSelectType == 1 || QSelectType == 2)
            {              
                lQ++;               
                word = wordList[lQ].word;
                holder = lQ;
            }
            if (QSelectType == 3)
            {
                if (failAnsw.Count != 0)
                {
                   
                    if (lQ == wordList.Count - 1)
                    {
                        base_pickFAp = 300;
                    }
                    float pickFAp = base_pickFAp * failAnsw.Count;
                    Random rnd = new Random();
                    int chance = rnd.Next(101);
                    Display(lQ, failAnsw.Count, pickFAp, chance);
                    if (chance < pickFAp)
                    {                      
                        holder = lQ;
                        lQ = failAnsw[rnd.Next(failAnsw.Count)];
                        base_pickFAp = 10;
                        
                    }
                    else
                    {
                        lQ++;
                        holder = lQ;
                        base_pickFAp += 10;
                    }

                }
                else
                {
                    lQ++;
                    holder = lQ;                           
                }
                word = wordList[lQ].word;
                
                
            }
            return word;
        }
        public string CheckAnswer(string answer)
        {
            string res="";
            if (wordList[lQ].trans == answer)
            {
                score++;
                maxscore++;
                res = "Correct answer!";
                if (failAnsw.Contains(lQ))
                {
                    failAnsw.Remove(lQ);
                }
            }
            else
            { 
                maxscore++; 
                res= "Bad answer, the correct was: " + wordList[lQ].trans + Environment.NewLine + wordList[lQ].definition;
                if (!failAnsw.Contains(lQ))
                {
                    failAnsw.Add(lQ);
                }
            }
            if (QSelectType == 3) // the random game time will never end so we apply the end game only to the others
            {
                lQ = holder;
                if (lQ == wordList.Count - 1 && failAnsw.Count == 0)
                {
                    EndGameEvent();
                }
            }
            if (QSelectType == 1 | QSelectType == 2) // the random game time will never end so we apply the end game only to the others
            {
                lQ = holder;
                if (lQ == wordList.Count - 1)
                {
                    EndGameEvent();
                }
            }
            return res;
        }
        public string GetDefinitionString()
        {
            return wordList[lQ].definition;
        }
    }
    public class Vocab
    {
        public List<WordItem> WordList = new List<WordItem>();
        public string name;

        public Vocab Clone()
        {
            Vocab clone = new Vocab();
            foreach(WordItem w in WordList)
            {
                clone.WordList.Add(w.Clone());
            }
            return clone;
        }
        public List<WordItem> CloneWordList()
        {
            List<WordItem> clone = new List<WordItem>();
            foreach (WordItem w in WordList)
            {
                clone.Add(w.Clone());
            }
            return clone;
        }
    }
    public class WordItem
    {
        public string word;
        public string trans;
        public string definition;

        public WordItem Clone()
        {
            WordItem clone = new WordItem();
            clone.word = word;
            clone.trans = trans;
            clone.definition = definition;
            return clone;
        }
    }
}
