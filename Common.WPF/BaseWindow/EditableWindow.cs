using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace Common.WPF
{

    public class EditableWindow : Window
    {

        #region Private Fields

        private static readonly double DefaultCaptionHeight = 35;
        private static readonly SolidColorBrush DefaultCaptionColor = SystemColors.WindowBrush;
        private static readonly SolidColorBrush DefaultCaptionBorderColor = SystemColors.WindowFrameBrush;
        private static readonly Thickness DefaultCaptionBorderThickness = new Thickness(0);
        private static readonly Thickness DefaultResizeBorderThickness = new Thickness(5);
        private static readonly SolidColorBrush DefaultButtonInteractionColor = SystemColors.ControlDarkBrush;
        private static readonly SolidColorBrush DefaultCaptionForeground = SystemColors.ActiveCaptionTextBrush;

        #endregion


        #region Dependency Properties

        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register("CaptionHeight", typeof(double), typeof(EditableWindow), new PropertyMetadata(DefaultCaptionHeight));

        public static readonly DependencyProperty CaptionColorProperty =
            DependencyProperty.Register("CaptionColor", typeof(SolidColorBrush), typeof(EditableWindow), new PropertyMetadata(DefaultCaptionColor));

        public static readonly DependencyProperty CaptionBorderColorProperty =
            DependencyProperty.Register("CaptionBorderColor", typeof(SolidColorBrush), typeof(EditableWindow), new PropertyMetadata(DefaultCaptionBorderColor));

        public static readonly DependencyProperty CaptionBorderThicknessProperty =
            DependencyProperty.Register("CaptionBorderThickness", typeof(Thickness), typeof(EditableWindow), new PropertyMetadata(DefaultCaptionBorderThickness));

        public static readonly DependencyProperty ResizeBorderThicknessProperty =
           DependencyProperty.Register("ResizeBorderThickness", typeof(Thickness), typeof(EditableWindow), new PropertyMetadata(DefaultResizeBorderThickness));

        public static readonly DependencyProperty ButtonInteractionColorProperty =
            DependencyProperty.Register("ButtonInteractionColor", typeof(SolidColorBrush), typeof(EditableWindow), new PropertyMetadata(DefaultButtonInteractionColor));

        public static readonly DependencyProperty CaptionForegroundProperty =
            DependencyProperty.Register("CaptionForeground", typeof(SolidColorBrush), typeof(EditableWindow), new PropertyMetadata(DefaultCaptionForeground));

        #endregion

        #region Properties

        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        public SolidColorBrush CaptionColor
        {
            get { return (SolidColorBrush)GetValue(CaptionColorProperty); }
            set { SetValue(CaptionColorProperty, value); }
        }

        public SolidColorBrush CaptionBorderColor
        {
            get { return (SolidColorBrush)GetValue(CaptionBorderColorProperty); }
            set { SetValue(CaptionBorderColorProperty, value); }
        }

        public Thickness CaptionBorderThickness
        {
            get { return (Thickness)GetValue(CaptionBorderThicknessProperty); }
            set { SetValue(CaptionBorderThicknessProperty, value); }
        }

        public Thickness ResizeBorderThickness
        {
            get { return (Thickness)GetValue(ResizeBorderThicknessProperty); }
            set { SetValue(ResizeBorderThicknessProperty, value); }
        }

        public SolidColorBrush ButtonInteractionColor
        {
            get { return (SolidColorBrush)GetValue(ButtonInteractionColorProperty); }
            set { SetValue(ButtonInteractionColorProperty, value); }
        }

        public SolidColorBrush CaptionForeground
        {
            get { return (SolidColorBrush)GetValue(CaptionForegroundProperty); }
            set { SetValue(CaptionForegroundProperty, value); }
        }

        #endregion


        #region Constructors

        static EditableWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableWindow), new FrameworkPropertyMetadata(typeof(EditableWindow)));
        }

        public EditableWindow()
        {
            Background = SystemColors.WindowBrush;

            var windowChrome = new WindowChrome()
            {
                CaptionHeight = this.CaptionHeight,
                ResizeBorderThickness = this.ResizeBorderThickness,
                GlassFrameThickness = new Thickness(1),
                CornerRadius = new CornerRadius(0),
                NonClientFrameEdges = NonClientFrameEdges.None,
                UseAeroCaptionButtons = false
            };

            WindowChrome.SetWindowChrome(this, windowChrome);
        }

        #endregion


        #region Commands

        public static readonly ICommand CloseCommand = new RelayCommand(w => ((Window)w).Close());
        public static readonly ICommand MaximizeCommand = new RelayCommand(w => ((Window)w).WindowState = WindowState.Maximized);
        public static readonly ICommand MinimizeCommand = new RelayCommand(w => ((Window)w).WindowState = WindowState.Minimized);
        public static readonly ICommand RestoreCommand = new RelayCommand(w => ((Window)w).WindowState = WindowState.Normal);

        #endregion

    }
}
