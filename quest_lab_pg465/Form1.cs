using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quest_lab_pg465
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<PictureBox> inventoryBoxes = new List<PictureBox>();

        private Game game;
        private Random random = new Random();
        private void Form1_Load(object sender,
            EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);

            Console.WriteLine("***Game Starting***");

            UpdateCharacters();
            //put the inventory boxes in a list
            inventoryBoxes.Add(swordInventory);
            inventoryBoxes.Add(bluePotionInventory);
            inventoryBoxes.Add(bowInventory);
            inventoryBoxes.Add(redPotionInventory);
            inventoryBoxes.Add(maceInventory);
        }

        public void UpdateCharacters()
        {
            Player.Location = game.PlayerLocation;
            playerHitPoints.Text =
                game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;
            //more code to go here... see pg 484

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        bat.Visible = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        ghost.Visible = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        ghoul.Visible = true;
                        enemiesShown++;
                    }
                }
            }

            if (showBat == false)
            {
                bat.Visible = false;
                batHitPoints.Text = "";
            }
            if (showGhost == false)
            {
                ghost.Visible = false;
                ghostHitPoints.Text = "";
            }
            if (showGhoul == false)
            {
                ghoul.Visible = false;
                ghoulHitPoints.Text = "";
            }

            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;
            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword; break;
                case "Bow":
                    weaponControl = bow; break;
                case "Red Potion":
                    weaponControl = redPotion; break;
                case "Blue Potion":
                    weaponControl = bluePotion; break;
                case "Mace":
                    weaponControl = mace; break;
            }
            weaponControl.Visible = true;

            //check the game object's checkplayerinventory() method
            //to figure out whether to display inventory icons

            if (game.CheckPlayerInventory("Sword") == true)
            {
                swordInventory.Visible = true;
            }
            else
            {
                swordInventory.Visible = false;
            }

            if (game.CheckPlayerInventory("Bow") == true)
            {
                bowInventory.Visible = true;
            }
            else
            {
                bowInventory.Visible = false;
            }

            if (game.CheckPlayerInventory("Red Potion") == true)
            {
                redPotionInventory.Visible = true;
            }
            else
            {
                redPotionInventory.Visible = false;
            }

            if (game.CheckPlayerInventory("Blue Potion") == true)
            {
                bluePotionInventory.Visible = true;
            }
            else
            {
                bluePotionInventory.Visible = false;
            }

            if (game.CheckPlayerInventory("Mace") == true)
            {
                maceInventory.Visible = true;
            }
            else
            {
                maceInventory.Visible = false;
            }

        

            //check to see if player has already picked up weapon in room
            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            //check if player died
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            //check if all enemies have been defeated
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                if (game.Level < 8)
                {
                    UpdateCharacters();
                }
            }
    }

        public void formEquip(string weaponName, string pictureBoxName)
        {
            if (game.CheckPlayerInventory(weaponName) == true)
            {
                game.Equip(weaponName);

                foreach (PictureBox item in inventoryBoxes)
                {
                    if (item.Name == pictureBoxName)
                    {
                        item.BorderStyle =
                            System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    else
                    {
                        item.BorderStyle =
                            System.Windows.Forms.BorderStyle.None;
                    }
                }
            }
        }

        public void potionAttackButtonsUpdate()
        {
            attackLeft.Visible = false;
            attackRight.Visible = false;
            attackDown.Visible = false;
            attackUp.Text = "Drink";
        }

        public void nonPotionAttackButtonsUpdate()
        {
            attackLeft.Visible = true;
            attackRight.Visible = true;
            attackDown.Visible = true;
            attackUp.Text = "↑";
        }

        private void swordInventory_Click(object sender, EventArgs e) //sword inventory
        {
            formEquip("Sword", "swordInventory");
            nonPotionAttackButtonsUpdate();
        }

        private void bluePotionInventory_Click(object sender, EventArgs e)
        {
            formEquip("Blue Potion", "bluePotionInventory");
            potionAttackButtonsUpdate();
        }

        private void bowInventory_Click(object sender, EventArgs e)
        {
            formEquip("Bow", "bowInventory");
            nonPotionAttackButtonsUpdate();
        }

        private void redPotionInventory_Click(object sender, EventArgs e)
        {
            formEquip("Red Potion", "redPotionInventory");
            potionAttackButtonsUpdate();
        }

        private void maceInventory_Click(object sender, EventArgs e)
        {
            formEquip("Mace", "maceInventory");
            nonPotionAttackButtonsUpdate();
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void attackRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }
    }
}
