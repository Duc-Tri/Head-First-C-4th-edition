﻿using System;
using System.Reflection;
using System.Windows;

namespace SwordDamage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SwordDamageCalculator swordDamageCalculator = new SwordDamageCalculator();

        public MainWindow()
        {
            InitializeComponent();
            swordDamageCalculator.Magic = cbMagic.IsChecked.Value;
            swordDamageCalculator.Flaming = cbMagic.IsChecked.Value;
            RollDice();

            FieldInfo[] fields = swordDamageCalculator.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.Name + " => " + field.GetValue(swordDamageCalculator));
            }
        }

        private void RollDice()
        {
            swordDamageCalculator.RollDice();
            DisplayDamage();
        }

        private void DisplayDamage()
        {
            Damage_Text.Text = "Rolled " + swordDamageCalculator.Roll + " for " + swordDamageCalculator.Damage + " HP\n" + swordDamageCalculator.ToString();
        }

        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamageCalculator.Magic = true;
            DisplayDamage();
        }

        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamageCalculator.Magic = false;
            DisplayDamage();
        }

        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamageCalculator.Flaming = true;
            DisplayDamage();
        }

        private void Flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamageCalculator.Flaming = false;
            DisplayDamage();
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }

    }

}
