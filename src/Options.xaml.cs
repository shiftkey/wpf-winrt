﻿using System.Windows;
using BabySmash.Properties;
using System.Diagnostics;
using System.Deployment.Application;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace BabySmash
{
   public partial class Options : Window
   {
      public Options()
      {
         InitializeComponent();
      }

      private void OK_Click(object sender, RoutedEventArgs e)
      {
         Settings.Default.Save();
         Close();
      }

      private void Cancel_Click(object sender, RoutedEventArgs e)
      {
         Settings.Default.Reload();
         Close();
      }

      protected override void OnActivated(EventArgs e)
      {
         base.OnActivated(e);
         Mouse.Capture(this, CaptureMode.SubTree);
         if (ApplicationDeployment.IsNetworkDeployed)
         {
            versionLabel.Text = "Version " + ApplicationDeployment.CurrentDeployment.CurrentVersion;
         }
      }

      protected override void OnDeactivated(EventArgs e)
      {
          base.OnDeactivated(e);
          Mouse.Capture(null);
      }
      protected override void OnMouseMove(MouseEventArgs e)
      {
          //Mouse.Capture(null);
          base.OnMouseMove(e);
      }

      protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
      {
         if (e.Key == Key.Escape)
         {
            // hitting "escape" is the new cancel button
            Settings.Default.Reload();
            Close();
         }
         else
         {
            base.OnKeyUp(e);
         }
      }

      private void FeedbackLink_Click(object sender, RoutedEventArgs e)
      {
         Process.Start("http://feedback.babysmash.com");
      }
   }
}