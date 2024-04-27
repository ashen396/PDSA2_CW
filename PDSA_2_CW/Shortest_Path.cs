using System;
using System.Drawing;
using System.Windows.Forms;
using PDSA_2_CW.Assets;

namespace PDSA_2_CW
{
    public partial class Shortest_Path : Form
    {
        int totRouteDistance = 0;
        char lastSelectedCharacter;
        char selectedCharacter;
        char keyChar;
        public Shortest_Path()
        {
            InitializeComponent();
            char character = RandomCharacter();
            keyChar = character;
            lastSelectedCharacter = character;
            SetRoutes(character);
            RandomDistances();
        }

        private void pnl_background_Paint(object sender, PaintEventArgs e)
        {
            AddElements(e);
        }

        int[] distances = new int[13];
        private void RandomDistances()
        {
            Random rand = new Random();
            for (int i = 0; i <= 12; i++)
            {
                distances[i] = rand.Next(5, 50);
            }
        }

        private char ReturnChar(int randomNumber)
        {
            switch (randomNumber)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                case 5:
                    return 'E';
                case 6:
                    return 'F';
                case 7:
                    return 'G';
                case 8:
                    return 'H';
                case 9:
                    return 'I';
                case 10:
                    return 'J';
                default:
                    return 'A';
            }
        }

        char randomChar;
        private char RandomCharacter()
        {
            Random random = new Random();
            int randomIndex = random.Next(1, 10);

            if (randomIndex != 0)
            {
                randomChar = ReturnChar(randomIndex);
                return randomChar;
            }
            else
            {
                RandomCharacter();
            }
            return 'A';
        }

        private void SetRoutes(char key)
        {
            int controlCounter = 8;
            int charCounter = 1;

            for (int i = 0; i < panelRoutes.Controls.Count; i++)
            {
                char returnedCharacter = ReturnChar(charCounter);
                if (!returnedCharacter.Equals(key))
                {
                    panelRoutes.Controls[controlCounter].Controls[0].Text = key + " -> " + returnedCharacter;
                    controlCounter--;
                }

                charCounter++;
            }
        }

        private void AddElements(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Images.roadEndWest, 504, 152);
            AddStringText(e, 'J', 504, 152);

            e.Graphics.DrawImage(Images.roadEast, 456, 176);
            AddDistance(e, distances[0], 456, 176);

            e.Graphics.DrawImage(Images.roadCornerWS, 312, 152);
            AddStringText(e, 'G', 312, 158);

            e.Graphics.DrawImage(Images.roadNorth, 360, 176);
            AddDistance(e, distances[1], 360, 176);

            e.Graphics.DrawImage(Images.crossroad, 408, 200);
            AddStringText(e, 'H', 408, 200);

            e.Graphics.DrawImage(Images.roadEast, 360, 224);
            AddDistance(e, distances[2], 360, 224);

            e.Graphics.DrawImage(Images.roadEast, 264, 176);
            AddDistance(e, distances[3], 264, 176);

            e.Graphics.DrawImage(Images.roadCornerES, 216, 200);
            AddStringText(e, 'D', 225, 200);

            e.Graphics.DrawImage(Images.roadNorth, 264, 224);
            AddDistance(e, distances[4], 264, 224);

            e.Graphics.DrawImage(Images.crossroad, 312, 248);
            AddStringText(e, 'C', 312, 248);

            e.Graphics.DrawImage(Images.roadEast, 264, 272);

            e.Graphics.DrawImage(Images.roadEast, 216, 296);
            AddDistance(e, distances[5], 216, 296);

            e.Graphics.DrawImage(Images.roadEndSouth, 24, 296);
            AddStringText(e, 'A', 24, 296);

            e.Graphics.DrawImage(Images.roadEast, 168, 320); 

            e.Graphics.DrawImage(Images.roadNorth, 72, 320); 
            AddDistance(e, distances[6], 72, 320);

            e.Graphics.DrawImage(Images.roadTEast, 120, 344);
            AddStringText(e, 'B', 125, 344);

            e.Graphics.DrawImage(Images.roadNorth, 168, 368);
            AddDistance(e, distances[7], 180, 380);

            e.Graphics.DrawImage(Images.roadNorth, 216, 392);

            e.Graphics.DrawImage(Images.roadNorth, 360, 272);
            AddDistance(e, distances[8], 368, 280);

            e.Graphics.DrawImage(Images.roadNorth, 456, 224);
            AddDistance(e, distances[9], 456, 224);

            e.Graphics.DrawImage(Images.roadNorth, 504, 248);

            e.Graphics.DrawImage(Images.roadNorth, 408, 296);

            e.Graphics.DrawImage(Images.roadCornerNW, 552, 272);
            AddStringText(e, 'I', 538, 272);

            e.Graphics.DrawImage(Images.roadEast, 504, 296);
            AddDistance(e, distances[10], 504, 296);

            e.Graphics.DrawImage(Images.roadTNorth, 456, 320);
            AddStringText(e, 'F', 456, 320);

            e.Graphics.DrawImage(Images.roadEast, 408, 344);

            e.Graphics.DrawImage(Images.roadEast, 360, 368);
            AddDistance(e, distances[11], 360, 368);

            e.Graphics.DrawImage(Images.roadEast, 312, 392);

            e.Graphics.DrawImage(Images.roadCornerNE, 264, 416);
            AddStringText(e, 'E', 264, 410);
        }
        private void AddStringText(PaintEventArgs e, char text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Name = text.ToString();
            lbl.Text = text.ToString();
            lbl.Font = new Font(FontFamily.GenericSansSerif, 18);
            lbl.BackColor = Color.Transparent;
            lbl.Location = new Point(x + 40, y + 10);

            if (text.Equals(randomChar))
            {
                lbl.ForeColor = Color.PaleVioletRed;
            }
            else
            {
                lbl.ForeColor = Color.White;
                lbl.Cursor = Cursors.Hand;
                lbl.MouseClick += Lbl_MouseClick;
            }

            pnl_background.Controls.Add(lbl);
        }

        private void AddDistance(PaintEventArgs e, int dis, int x, int y)
        {
            e.Graphics.DrawString(dis.ToString(), new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular), new SolidBrush(Color.White), x + 40, y + 20);
        }

        bool isStarted = false;
        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {
            if (isSelected)
            {
                Control controller = (Control)sender;
                Control[] found = controller.Parent.Controls.Find(controller.Name, false);
                {
                    SelectedCounter((Control)found[0]);
                }
            }
        }

        private int ReturnIndexSelected(char last, char selected)
        {
            if((last.Equals('J') || last.Equals('H')) && (selected.Equals('J') || selected.Equals('H')))
                return 0;

            if ((last.Equals('G') || last.Equals('H')) && (selected.Equals('G') || selected.Equals('H')))
                return 1;

            if ((last.Equals('C') || last.Equals('H')) && (selected.Equals('C') || selected.Equals('H')))
                return 2;

            if ((last.Equals('D') || last.Equals('G')) && (selected.Equals('D') || selected.Equals('G')))
                return 3;

            if ((last.Equals('D') || last.Equals('C')) && (selected.Equals('D') || selected.Equals('C')))
                return 4;

            if ((last.Equals('B') || last.Equals('C')) && (selected.Equals('B') || selected.Equals('C')))
                return 5;

            if ((last.Equals('A') || last.Equals('B')) && (selected.Equals('A') || selected.Equals('B')))
                return 6;

            if ((last.Equals('B') || last.Equals('E')) && (selected.Equals('B') || selected.Equals('E')))
                return 7;

            if ((last.Equals('C') || last.Equals('F')) && (selected.Equals('C') || selected.Equals('F')))
                return 8;

            if ((last.Equals('I') || last.Equals('H')) && (selected.Equals('I') || selected.Equals('H')))
                return 9;

            if ((last.Equals('F') || last.Equals('I')) && (selected.Equals('F') || selected.Equals('I')))
                return 10;

            if ((last.Equals('E') || last.Equals('F')) && (selected.Equals('E') || selected.Equals('F')))
                return 11;

            return -1;
        }

        int[] totalRouteDistance = new int[12];
        int routeIndex = 0;

        private void SelectedCounter(Control control)
        {
            selectedCharacter = char.Parse(control.Text.ToString());

            int index = ReturnIndexSelected(lastSelectedCharacter, selectedCharacter);
            if (index != -1)
            {
                totRouteDistance += distances[index];
                control.ForeColor = Color.Aqua;
                //MessageBox.Show(lastSelectedCharacter + " " + selectedCharacter + " : " + totRouteDistance);
                lastSelectedCharacter = selectedCharacter;

                if (selectedCharacter.Equals(lastChar))
                {
                    totalRouteDistance[routeIndex] = totRouteDistance;
                    routeIndex++;
                    isSelected = false;
                    lastSelectedCharacter = keyChar;

                    foreach (Control controlSel in pnl_background.Controls)
                    {
                        if (controlSel.GetType().Equals(typeof(Label))){
                            if (controlSel.Text.Equals(keyChar.ToString()))
                            {
                                continue;
                            }
                            controlSel.ForeColor = Color.White;
                        }
                    }

                    MessageBox.Show("Done for selected route");
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Please choose a valid path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool isSelected = false;
        char lastChar;
        private void pnlSelectedCity(object sender, EventArgs e)
        {
            if (!isSelected)
            {
                Control control = ((Control)sender).Controls[0];
                lastChar = control.Text.ToCharArray(control.Text.Length - 1, 1)[0];
                Control[] selControl = control.Parent.Controls.Find(control.Name, false);
                selControl[0].BackColor = Color.Gray;
                selControl[0].Enabled = false;
                control.BackColor = Color.Gray;
                control.Parent.BackColor = Color.Gray;
                control.Enabled = false;
                control.Parent.Enabled = true;
                isSelected = true;
            }
        }

        private void DisjkstrasAlgorithm()
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();

        }
    }
}
