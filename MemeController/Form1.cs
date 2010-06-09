using System;
using System.Drawing;
using System.Windows.Forms;
using CustomMemes;
using MemeLibrary;
using NpcLibrary;

namespace MemeController
{
    public partial class Form1 : Form
    {
        #region Member Variables

        private WanderMeme _wander;
        private ExhaustionMeme _exausted;
        private int _roomCounter;
        private Npc _testNpc;

        #endregion

        #region Delegates

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        private delegate void SetTextCallback(string text);

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();

            MarkAllRoomsUnoccupied();

            LoadNpc();
        }

        private void LoadNpc()
        {
            LogToScreen("Creating NPC...");

            _testNpc = new Npc();

            LogToScreen("Adding Wander meme to NPC...");
            _wander = new WanderMeme();

            LogToScreen("Adding Exhaustion meme to NPC...");
            _exausted = new ExhaustionMeme();

            _testNpc.Memes.AddMeme(_wander);
            _testNpc.Memes.AddMeme(_exausted);
        }

        #endregion

        #region Form Events

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnLoad.Enabled = false;

            _wander.OnMemeEventHasFired += _wander_OnMemeEventHasFired;
            _exausted.OnMemeEventHasFired += _exausted_OnMemeEventHasFired;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

             LogToScreen("Firing up the memes in the NPC...");

            _testNpc.StartMemes();

             LogToScreen("Memes in the NPC have been started.");

            CreateSeparator();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            CreateSeparator();

             LogToScreen("Stopping the memes in the NPC...");

            _testNpc.StopMemes();

             LogToScreen("Memes in the NPC have been stopped.");
             LogToScreen("Whew, time to rest!");

            CreateSeparator();
        }

        #endregion

        #region Event Handlers

        private void _wander_OnMemeEventHasFired(Meme meme, MemeEvent memeEvent)
        {
            string msg = meme.Name + " has fired." + Environment.NewLine;
            SetText(msg);
            ProcessRoom();
        }

        void _exausted_OnMemeEventHasFired(Meme meme, MemeEvent memeEvent)
        {
        }

        #endregion

        #region Private Members

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (txtLog.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] {text});
            }
            else
            {
                txtLog.Text += text;
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.SelectionLength = 0;
                txtLog.ScrollToCaret();
            }
        }

        private void LogToScreen(string message)
        {
            string msg = message + Environment.NewLine;
            SetText(msg);
        }

        private void CreateSeparator()
        {
            string msg = "=======================================" + Environment.NewLine;
            SetText(msg);
        }

        private void ProcessRoom()
        {
            _roomCounter++;

            switch (_roomCounter)
            {
                case 1:
                    MarkRoomOccupied(pRoom1);
                    LogToScreen("Wandering over to room 1...");
                    MarkRoomEmpty(pRoom10);
                    break;
                case 2:
                    MarkRoomOccupied(pRoom2);
                     LogToScreen("Wandering over to room 2...");
                    MarkRoomEmpty(pRoom1);
                    break;
                case 3:
                    MarkRoomOccupied(pRoom3);
                    LogToScreen("Wandering over to room 3...");
                    MarkRoomEmpty(pRoom2);
                    break;
                case 4:
                    MarkRoomOccupied(pRoom4);
                    LogToScreen("Wandering over to room 4...");
                    MarkRoomEmpty(pRoom3);
                    break;
                case 5:
                    MarkRoomOccupied(pRoom5);
                    LogToScreen("Wandering over to room 5...");
                    MarkRoomEmpty(pRoom4);
                    break;
                case 6:
                    MarkRoomOccupied(pRoom6);
                    LogToScreen("Wandering over to room 6...");
                    MarkRoomEmpty(pRoom5);
                    break;
                case 7:
                    MarkRoomOccupied(pRoom7);
                    LogToScreen("Wandering over to room 7...");
                    MarkRoomEmpty(pRoom6);
                    break;
                case 8:
                    MarkRoomOccupied(pRoom8);
                    LogToScreen("Wandering over to room 8...");
                    MarkRoomEmpty(pRoom7);
                    break;
                case 9:
                    MarkRoomOccupied(pRoom9);
                    LogToScreen("Wandering over to room 9...");
                    MarkRoomEmpty(pRoom8);
                    break;
                case 10:
                    MarkRoomOccupied(pRoom10);
                    LogToScreen("Wandering over to room 10...");
                    MarkRoomEmpty(pRoom9);
                    break;
            }

            if (_roomCounter > 10)
            {
                _roomCounter = 0;
            }
        }

        private void MarkRoomOccupied(Panel room)
        {
            room.BackColor = Color.Firebrick;
        }

        private void MarkRoomEmpty(Panel room)
        {
            room.BackColor = Color.SkyBlue;
        }

        private void MarkAllRoomsUnoccupied()
        {
            MarkRoomEmpty(pRoom1);
            MarkRoomEmpty(pRoom2);
            MarkRoomEmpty(pRoom3);
            MarkRoomEmpty(pRoom4);
            MarkRoomEmpty(pRoom5);
            MarkRoomEmpty(pRoom6);
            MarkRoomEmpty(pRoom7);
            MarkRoomEmpty(pRoom8);
            MarkRoomEmpty(pRoom9);
            MarkRoomEmpty(pRoom10);
        }

        #endregion
    }
}