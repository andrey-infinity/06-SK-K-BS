using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Collections;



namespace Burtu_spele
{
    public partial class Form1 : Form
    {
        public partial class MyNewButton : Label
        {
            private int _MyIndex;
            private int _i;
            private int _j;
            private int _dir1;
            private int _dir2;
            private bool _Checked;
            private bool _MChecked = false;

            public bool MChecked {
                set { _MChecked = value; }
                get { return _MChecked; }
            
            }
            public int dir1
            {
                set { _dir1 = value; }
                get { return _dir1; }
            }
            public int dir2
            {
                set { _dir2 = value; }
                get { return _dir2; }
            }
            public int i
            {
                set { _i = value; }
                get { return _i; }
            }
            public int j
            {
                set { _j = value; }
                get { return _j; }
            }
            public bool Checked
            {
                set { _Checked = value; }
                get { return _Checked; }
            }
            public int MyIndex
            {
                set { _MyIndex = value; }
                get { return _MyIndex; }
            }
        }


        private ArrayList _ASkin;
        public ArrayList ASkin
        {
            set { _ASkin = value; }
            get { return _ASkin; }
        }
        ArrayList _NewAllWords = new ArrayList();
        ArrayList stack = new ArrayList();
        ArrayList POLE = new ArrayList();
        string[] args;
        string[] _Laukums;
        string[] _AllWords;

        int _OK = 0;
        int N = 0;
        int M = 0;
        int K = 0;
        int _level = 2;

        public int level {
            set { _level = value; }
            get { return _level; }
        }
        private ArrayList get_avail_skins()
        {
            ArrayList res = new ArrayList();

            string path = Application.StartupPath + "\\skins";
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fi = di.GetFiles();

            foreach (FileInfo fiTemp in fi)
            {
                res.Add(path + "\\" + fiTemp);
                //MessageBox.Show(fiTemp.Name);
            }

            return res;
        }
        private bool Check_w(out string WArray, StreamReader sr,int count,string regexp,out string last){
            int i=1;
            bool err = false;
            string L = ""; ;
            string mydataline = "" ;

            while (((mydataline = sr.ReadLine()) != null) && (i <= count) && (err!=true)) {
            string pat = regexp;
            mydataline=mydataline.Trim();
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match mat = r.Match(mydataline);
            if ((mat.Success != true))
               {
                 err = true;
               }
               else {
                 L += mydataline+"|";
               }
               i++;
            }


            WArray = L;
            last = mydataline;


            if ((err) || (i <= count))
            {
                return false;
            }
            else
            { 
                return true;
            }
        
        
        }
        private bool Check_validation(string FileName,out int _1N,out int _1M,out string[] _1Laukums,out string[] _1AllWords,out int _1K) {
            int M=0;
            int N=0;
            int K=0;
            string[] nu = { " ", " " };
            string[] Laukums=nu;
            string[] AllWords=nu;
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    #region Check FirstLine
                    String firstline="";
                    string pat = @"^[0-9]+ +[0-9]+$";
                    firstline = sr.ReadLine();
                    firstline=firstline.Trim();
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match mat = r.Match(firstline);
                    if (mat.Success != true)
                    {
                        _1N = N;
                        _1M = M;
                        _1Laukums = Laukums;
                        _1K = K;
                        _1AllWords = AllWords;
                        return mat.Success;
                    }
                    else
                    {
                        string tmp = mat.Groups[0].Captures[0].ToString();
                        tmp.TrimStart();
                        tmp.TrimEnd();
                        string[] ar = tmp.Split(new Char[] { ' ' }, 2);
                        ar[1]= ar[1].Trim();
                        ar[0]= ar[0].Trim();
                        N = Convert.ToInt32(ar[0]);
                        M = Convert.ToInt32(ar[1]);
                    }
                    #endregion


                    #region Check_Field
                    string qwe="";
                    string mydataline = "";
                    if (Check_w(out qwe, sr, N, @"^\w{" + M + "," + M + "}$", out mydataline) != true)
                    {
                        _1N = N;
                        _1M = M;
                        _1Laukums = Laukums;
                        _1K = K;
                        _1AllWords = AllWords;
                       return false;  
                    }
                    Laukums=qwe.Split('|');
                    qwe = "";
                    #endregion


                    #region Check K
                    pat = @"^[0-9]+$";
                    r = new Regex(pat, RegexOptions.IgnoreCase);
                    mat = r.Match(mydataline);
                    if (mat.Success != true)
                        {
                            _1N = N;
                            _1M = M;
                            _1Laukums = Laukums;
                            _1K = K;
                            _1AllWords = AllWords;
                            return mat.Success;
                        }
                        else {
                            mydataline= mydataline.Trim();

                            K = Convert.ToInt32(mydataline);
                        
                        }
                    
                    #endregion


                    #region Check_Words
                    if (Check_w(out qwe, sr, K, @"^\w+$", out mydataline) != true)
                    {
                        _1N = N;
                        _1M = M;
                        _1Laukums = Laukums;
                        _1K = K;
                        _1AllWords = AllWords;
                        return false;
                    }
                    AllWords = qwe.Split('|');
                    #endregion


                    #region End_File
                    if (mydataline != null)
                    {
                        _1N = N;
                        _1M = M;
                        _1Laukums = Laukums;
                        _1K = K;
                        _1AllWords = AllWords;
                        return false;
                    }
                    #endregion


                    sr.Close();
                }
                
            }
            catch (FileNotFoundException e) {
                MessageBox.Show(e.Message);
            }

            _1N = N;
            _1M = M;
            _1Laukums = Laukums;
            _1K = K;
            _1AllWords = AllWords;



            return true;
        }
        private string reversstring(string s) { 
            string newres="";
            foreach (char c in s) {
                newres = c + newres ;
             }
            return newres;
        
        }
        private string getstring() {
            string Myres = "";
            foreach (MyNewButton gi in stack)
            {
                Myres = Myres + gi.Text;
            }
            return Myres;
        }
        private void EndGame() {
            MessageBox.Show("You WIN!!!!");
            closeToolStripMenuItem_Click(this, null);
        }
        private void SetFinal() {
            for (int i = 0; i < stack.Count; i++) {
                MyNewButton tmp = (MyNewButton)stack[i];
                tmp.MChecked = true;
                tmp.Checked = false;
                tmp.BackColor = Color.IndianRed;
            }
            
            del_stack(null) ;

        }
        private bool check_word(){
            string tmpzy = "";
            string tmpxy = "";
            string torem = "";
            tmpzy = getstring();
            bool need = false;
            foreach (string workWith in _NewAllWords) {
                tmpxy = reversstring(workWith);
                if ((workWith == tmpzy) || (tmpxy == tmpzy))
                {
                    need = true;
                    torem = workWith;
                }
            
            }
            if (need)
            {
                
                SetFinal();
                need = false;
                _NewAllWords.Remove(torem);
                --K;
                if (K == 0)
                {
                    EndGame();
                }
                view_all_words();
                return true;
            }
            else { return false; }
            
        }
        private void Start_game() {
            view_all_words();

            int counter = 0;
            int i = 1;
            int j = 1;
            for (i = 1; i <= M; i++) {
                for (j = 1; j <= N; j++) {
                    MyNewButton myButton = new MyNewButton();
                    myButton.Name = "B " + i*j;
                    myButton.Text = _Laukums[j - 1][i - 1].ToString();//"B " + i * j;
                    myButton.Location = new Point(12+(i-1)*45,24+(j-1)*45);

                    myButton.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
                    //myButton.MouseEnter += new System.EventHandler(this.button2_Click);

                    myButton.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
                    myButton.Click += new System.EventHandler(this.button2_Click);
                    myButton.Height = 40;
                    myButton.Width = 40;
                    myButton.i = i;
                    myButton.j = j;
                    myButton.MyIndex = counter;
                    POLE.Add(myButton);
                    this.SC.Panel1.Controls.Add((MyNewButton)POLE[counter]);
                    //this.Controls.Add((MyNewButton)POLE[counter]);
                    counter++;
                    this.Show();
                }
            
            }
            SC.Visible = true;
            


        }
        private void del_stack(MyNewButton bt) {
            if (bt == null)
            {
                int i = 0;
                for (i = stack.Count-1 ; i >= 0; i--) {
                    MyNewButton tmpz = (MyNewButton)stack[i];
                    tmpz.Checked = false;
                    LightOff(tmpz);
                    stack.Remove(stack[i]);                
                }

 

                
            }
            else
            {
                int i = stack.Count - 1;
                while (bt.Equals(stack[i]) != true)
                {
                    --i;
                }
                if (i > 0)
                {
                    int j = stack.Count - 1;
                    while (j != i)
                    {
                        stack.Remove(stack[j]);
                    }

                }
            }
        
        }
        private bool check(MyNewButton old_b, MyNewButton new_b)
        {
            int Last_1 = 0;
            int Last_2 = 0;
            make_dir(old_b.i, old_b.j, new_b.i, new_b.j, out Last_1, out Last_2);
            if ((Last_1 == -1) || (Last_2 == -1))
            {
                return false;
            }
            else
            {
                if ((old_b.dir2 == Last_1) || (old_b.dir2 == Last_2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }




        }
        private void LightOn(MyNewButton bt){
            if ((bt.Checked != true))
            {
                    bt.BackColor = Color.BlanchedAlmond;
               
            }
        }
        private void LightOff(MyNewButton bt) {
            if ((bt.Checked != true)||(bt.MChecked))
            {
                if (bt.MChecked) {
                    if (bt.Checked) {
                        bt.BackColor = Color.DarkSlateBlue;
                    }
                    else
                    {
                        bt.BackColor = Color.IndianRed;
                    }
                }
                else
                {
                    bt.BackColor = Control.DefaultBackColor;
                }
            }
            //else if (bt.Checked) {
            //    bt.BackColor = Color.DarkSlateBlue;
             
            //}
        
        }
        private void make_dir(int i, int j, int i1, int j1,out int fir,out int sec)
        {
            int dir1 = 0;
            int dir2 = 0;
            bool res1 = ((j == j1) && ((i == i1 - 1) || (i == i1 + 1))); //7-3
            bool res2 = ((i == i1) && ((j == j1 - 1) || (j == j1 + 1))); //5-1
            bool res3 = (((i + 1 == i1) && (j + 1 == j1)) || ((i - 1 == i1) && (j - 1 == j1)));//8-4
            bool res4 = (   ((i+1==i1)&&(j-1==j1))||((i-1==i1)&&(j+1==j1)) );    //6-2                                         
            if (res1) {
                dir1 = 7;
                dir2 = 3;
            }
            else if (res2)
            {
                dir1 = 5;
                dir2 = 1;
            }
            else if (res3)
            {
                dir1 = 8;
                dir2 = 4;

            }
            else if(res4){
                dir1 = 6;
                dir2 = 2;
            }else {
            dir1=-1;
                dir2=-1;
            }
            fir = dir1;
            sec = dir2;

        }
        private bool can_add(MyNewButton bt,out bool add) {
            if (stack.Count == 0)
            {
                stack.Add(bt);
                if (check_word())
                {
                    add = true;
                    return false;
                }
                else
                {

                    add = false;
                    return true;
                }
            }
            else if (stack.Count - 1 == 0)
                {
                    MyNewButton tmpz = (MyNewButton)stack[stack.Count - 1];
                    int av_i = 0;
                    int av_i1 = 0;
                    int av_j = 0;
                    int av_j1 = 0;
                    av_i = tmpz.i + 1;
                    av_i1 = tmpz.i - 1;
                    av_j = tmpz.j + 1;
                    av_j1 = tmpz.j - 1;
                    if ((((bt.i == av_i) || (bt.i == av_i1)) && ((bt.j == av_j) || (bt.j == av_j1))) || (((bt.i == tmpz.i) && ((bt.j == av_j) || (bt.j == av_j1))) || ((bt.j == tmpz.j) && ((bt.i == av_i) || (bt.i == av_i1)))))
                    {
                        int dir1 = 0;
                        int dir2 = 0;
                        make_dir(tmpz.i,tmpz.j,bt.i,bt.j,out dir1,out dir2);
                        bt.dir1 = dir1;
                        bt.dir2 = dir2;
                        tmpz.dir1 = dir1;
                        tmpz.dir2 = dir2;
                        stack.Add(bt);
                        if (check_word())
                        {
                            add = true;
                            return false;
                        }
                        else
                        {

                            add = false;
                            return true;
                        }
                    }else {
                        add = false;
                        return false;
                    }
                }
            else {
                MyNewButton tmpz = (MyNewButton)stack[stack.Count - 1];
                MyNewButton tmpy = (MyNewButton)stack[0];
                int Last_1 = 0;
                int First_1=0;
                int Last_2 = 0;
                int First_2 = 0;
                bool konec = false;
                bool na4 = false;
                make_dir(tmpz.i, tmpz.j, bt.i, bt.j, out Last_1, out Last_2);
                make_dir(tmpy.i, tmpy.j, bt.i, bt.j, out First_1, out First_2);
                konec=check(tmpz, bt);
                na4 = check(tmpy, bt);
                if (konec) {
                        bt.dir1 = tmpz.dir1;
                        bt.dir2 = tmpz.dir2;
                        stack.Add(bt);
                        if (check_word()) {
                            add = true; return false;
                        }
                        else
                        {
                            add = false;
                            return true;
                        }
                }else if (na4){
                    bt.dir1 = tmpz.dir1;
                    bt.dir2 = tmpz.dir2;
                    stack.Insert(0, bt);
                    if (check_word()) {
                        add = true; return false;
                    }
                    else
                    {
                        add = false;
                        return true;
                    }
                
                }
                //if (((First_1==-1)||(Last_1==-1))&&((First_2==-1)||(Last_2==-1))){
                //    return false;
                //}
                //if ((tmpz.dir1 == First_1) || (tmpz.dir1 == Last_1))
                //{
                //    bt.dir1 = tmpz.dir1;
                //    bt.dir2 = tmpz.dir2;
                //    stack.Add(bt);
                //    View_stack();
                //    return true;
                //}
                else
                {
                    add = false;
                    return false;
                }
                 }
      }
        private void view_all_words() {
            words.Items.Clear();
            foreach (string tmpz in _NewAllWords) {
                words.Items.Add(tmpz);
            }
            lb_wleft.Text="Words Left: "+K.ToString();
        
        }
        private void init_vars() {
            foreach (string gi in _AllWords)
            {
                _NewAllWords.Add(gi);
            }
            _NewAllWords.Remove("");
            foreach (MyNewButton tmpz in POLE)
            {
                tmpz.Dispose();
            }
   
        }
        private void Open_file(string FileName)
        {
            N = 0;
            M = 0;
            K = 0;
            if (Check_validation(FileName,out N,out M,out _Laukums,out _AllWords,out K))
            {
                _OK = K;
                init_vars();
                //Read_Config();
                Start_game();
            }
            else
            {
                MessageBox.Show("ERR");
            };
        
        }
        private void Open_Title() {

            this.Visible = false;
            Intro_Form test = new Intro_Form();
            test.Show();
        
        }
        public Form1(string[] args1)
        {
            InitializeComponent();
            args = args1;
        }


        private void Load_skin(string FILENAME) { 
        try
            {
                this.BackgroundImage = Image.FromFile(FILENAME);
                this.menuStrip1.BackgroundImage = this.BackgroundImage;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
        
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ASkin = get_avail_skins();
            if (ASkin.Count > 0)
            {
                Load_skin(ASkin[0].ToString());
            }
            if (args.Length > 0)
            {
                Open_file(args[0]);
            }


        }




        #region Label_handler
        private void button2_Click(object sender, EventArgs e)
        {
            bool add = false;
            MyNewButton currentButton = (MyNewButton)sender;
            if (currentButton.Checked)
            {
                del_stack(null);
                currentButton.BackColor = Color.DarkSlateBlue;
                currentButton.Checked = true;
                stack.Add(currentButton);
            }
            else
            {
                if (can_add(currentButton,out add))
                {

                    currentButton.BackColor = Color.DarkSlateBlue;
                    currentButton.Checked = true;
                }
                else
                {
                    if (add)
                    {
                        add = false;
                    }
                    else
                    {
                        del_stack(null);
                        stack.Add(currentButton);
                        currentButton.BackColor = Color.DarkSlateBlue;
                        currentButton.Checked = true;
                    }
                }
            }

        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            
            MyNewButton currentButton = (MyNewButton)sender;

            LightOn(currentButton);
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            MyNewButton currentButton = (MyNewButton)sender;

            LightOff(currentButton);
        }
#endregion

        #region Menu_Buttons_Handler
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox gi = new AboutBox(this);
            gi.Show();
            
        }
        private void viewRecordTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Records gi = new Records(this);
            gi.Show();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelEventArgs ee = new CancelEventArgs(false);
            Application.Exit(ee);
        }
        private void viewRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules temp = new Rules();
            temp.Show();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OD.ShowDialog() == DialogResult.OK)
            {
                Open_file(OD.FileName.ToString());
            }
        }
        #endregion





    }
}





#region Check Words
//int i=1;
//bool err = false;
//string L = ""; ;
//string mydataline = "" ;
//while (((mydataline = sr.ReadLine()) != null) && (i <= N) && (err!=true)) {
//    pat = @"^\w+$";
//    r = new Regex(pat, RegexOptions.IgnoreCase);
//    mat = r.Match(mydataline);
//    if ((mat.Success != true) || (mydataline.Length != M))
//    {
//        err = true;
//    }
//    else {
//      L += mydataline+"|";
//    }
//    i++;


//}
//Laukums=L.Split('|');
//if ((err) || (i < N))
//{
//    //i--;
//    //MessageBox.Show("Error on:"+ i.ToString());
//    return false;
//}
#endregion
//"C:\\Documents and Settings\\SiTox\\Desktop\\My Documents\\burtuspele\\pirmais.bkm"

            //if (File.Exists(FileName) != true)
            //{
            //    MessageBox.Show("cry out loud");
            //}
            //else
            //{
            //    MessageBox.Show("ALL O.K");
            //}









//else {
//                    MessageBox.Show("ERR");
//                    
//                    Application.Exit(ee);
//                  }


//public partial class MyArrayList : ArrayList
//{
//    private string[] _AllWords;
//    public string[] AllWords
//    {
//        set { _AllWords = value; }
//        get { return _AllWords; }
//    }
//    public bool check(string need)
//    {
//        bool res = false;
//        int i = 0;
//        foreach (string tmp in _AllWords)
//        {
//            if (tmp == need) { res = true; }
//            i++;
//        }
//        return res;

//    }
//    public string makestring()
//    {
//        string haz = "";
//        foreach (MyNewButton tmp in this)
//        {
//            haz += tmp.Text;
//        }
//        return haz;
//    }
//    public int Add(object value, out int game_over_flag)
//    {
//        int go = 0;
//        int gi = 0;
//        gi = this.Add(value);
//        string n1 = makestring();
//        if (check(n1))
//        {
//            go = 1;
//        }
//        game_over_flag = go;
//        return gi;
//    }

//}
#region
/*
 * 
 * 
 *         private void Count_Scoure() { 
          MessageBox.Show(((M*N*_OK*level)/Get_Time()).ToString());
        }
 * 
 * 
 * 
 *         private void Set_Interval() {
            Start_Game_Time = DateTime.Now;

        }
        private int Get_Time() {
            int res=0;
            DateTime tmp = DateTime.Now;
            TimeSpan gi;
            gi = tmp.Subtract(Start_Game_Time);
            res = gi.Seconds + gi.Minutes * 60 + gi.Hours * 360;
            return res;
        }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *         bool _sound = false;
        
        public string Nick {
            set { _Nick = value; }
            get { return _Nick; }
        }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *         public bool sound
        {
            set { _sound = value; }
            get { return _sound; }
        }
        public void Read_Players() {
            string tmp = "";
            tmp = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
            StreamReader sr = new StreamReader(tmp + "\\Players.xml");

            XmlTextReader xr = new XmlTextReader(sr);
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xr);

            XmlNode options = xdoc.FirstChild.NextSibling;
            XmlNodeList gi = xdoc.SelectNodes("players");
            XmlNode _nick = gi.Item(0).SelectSingleNode("nick");


        }
        public void Write_Config()
        {

        }
 * 
 * 
 * 
 * 
 * 

        public void Read_Config() {
            string tmp = "";
            tmp = Application.ExecutablePath.Substring(0,Application.ExecutablePath.LastIndexOf("\\"));
            StreamReader sr= new StreamReader(tmp+"\\config.xml");
           
            XmlTextReader xr = new XmlTextReader(sr);
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xr);
            XmlNode options = xdoc.FirstChild.NextSibling;
            XmlNodeList gi = xdoc.SelectNodes("options");
            XmlNode _nick = gi.Item(0).SelectSingleNode("nick");
            XmlNode _sound = gi.Item(0).SelectSingleNode("sound");
            XmlNode _level = gi.Item(0).SelectSingleNode("level");

            Nick = _nick.InnerText.ToString();
            tmp = _level.InnerText.ToString();
            level = Convert.ToInt32(tmp);
            tmp = _sound.InnerText.ToString();
            sound = Convert.ToBoolean(tmp);
        }*/
#endregion