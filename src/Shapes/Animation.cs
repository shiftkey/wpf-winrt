﻿using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace BabySmash
{
   class Animation
   {
      public static BitmapEffect GetRandomBitmapEffect()
      {
         int e = Utils.RandomBetweenTwoNumbers(0, 3);
         switch (e)
         {
            case 0:
               return new BevelBitmapEffect();
            case 1:
               return new DropShadowBitmapEffect();
            case 2:
               return new EmbossBitmapEffect();
            case 3:
               return new OuterGlowBitmapEffect();
         }
         return new BevelBitmapEffect();
      }

      public static void ApplyRandomAnimationEffect(FrameworkElement fe, Duration duration)
      {
         int e = Utils.RandomBetweenTwoNumbers(0, 3);
         switch (e)
         {
            case 0:
               ApplyJiggle(fe, duration);
               break;
            case 1:
               ApplySnap(fe, duration);
               break;
            case 2:
               ApplyThrob(fe, duration);
               break;
            case 3:
               ApplyRotate(fe, duration);
               break;
         }
      }


      public static Storyboard CreateDPAnimation(FrameworkElement container, UIElement shape,
                                                          DependencyProperty dp, Duration duration, double from, double to)
      {
         var st = new Storyboard();
         NameScope.SetNameScope(container, new NameScope());
         container.RegisterName("shape", shape);

         var d = new DoubleAnimation
         {
            From = from,
            To = to,
            Duration = duration,
            AutoReverse = false
         };

         st.Children.Add(d);
         Storyboard.SetTargetName(d, "shape");
         Storyboard.SetTargetProperty(d, new PropertyPath(dp));
         return st;
      }

      public static void ApplyJiggle(FrameworkElement fe, Duration duration)
      {
         DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(10, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(-10, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(5, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(-5, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));

         da.Duration = duration;
         da.AccelerationRatio = da.DecelerationRatio = 0.2;

         fe.RenderTransformOrigin = new Point(0.5, 0.5);
         fe.RenderTransform = new RotateTransform(0);
         fe.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, da);
      }

      public static void ApplyThrob(FrameworkElement fe, Duration duration)
      {
         DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1.1, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0.9, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1.05, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0.95, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));

         da.Duration = duration;
         da.AccelerationRatio = da.DecelerationRatio = 0.2;

         fe.RenderTransformOrigin = new Point(0.5, 0.5);
         fe.RenderTransform = new ScaleTransform(1, 1);
         fe.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, da);
         fe.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, da);
      }

      public static Timeline ApplyZoom(FrameworkElement fe, Duration duration, double scale)
      {
          var da = new DoubleAnimation
          {
              From = 1,
              To = scale,
              Duration = duration,
              AutoReverse = true
          };

          da.AccelerationRatio = da.DecelerationRatio = 0.2;

          fe.RenderTransformOrigin = new Point(0.5, 0.5);
          fe.RenderTransform = new ScaleTransform(scale, scale);
          fe.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, da);
          fe.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, da);
          return da;
      }


      public static void ApplyRotate(FrameworkElement fe, Duration duration)
      {
         DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(-5, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(90, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(180, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(270, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(360, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(365, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(360, KeyTime.Paced));

         da.Duration = duration;
         da.AccelerationRatio = da.DecelerationRatio = 0.2;

         fe.RenderTransformOrigin = new Point(0.5, 0.5);
         fe.RenderTransform = new RotateTransform(0);
         fe.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, da);
      }

      public static void ApplySnap(FrameworkElement fe, Duration duration)
      {
         DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.Paced));
         da.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.Paced));

         da.Duration = duration;
         da.AccelerationRatio = da.DecelerationRatio = 0.2;

         fe.RenderTransformOrigin = new Point(0.5, 0.5);
         fe.RenderTransform = new ScaleTransform(1, 1);
         fe.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, da);
      }
   }
}
