   M S B A M L   `   `   `  ����E  ASecureInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SecureInfo
SecureInfo  5   	   =#clr-namespace:SecureInfo.ViewModelsSecureInfo.ViewModels  5   	   W0clr-namespace:SecureInfo.Infrastructure.Commands"SecureInfo.Infrastructure.Commands  5   	   !    SecureInfo.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SecureInfo     5   	   2vm#clr-namespace:SecureInfo.ViewModels     5   	   @cmd0clr-namespace:SecureInfo.Infrastructure.Commands     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   _ [Hardcodet.NotifyIcon.Wpf, Version=1.1.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar  5
   	     � WindowStyle$
  None=�5   	    � AllowsTransparency . 
������ 
������  � Icon$ 
appIco.ico��5   	    � 
ResizeMode$ 	CanResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��700��6   $
��1200��6)    � DataContext 5      /  )SecureInfo.ViewModels.MainWindowViewModel  5   
    � 	Resources 5      >  8SecureInfo.Infrastructure.Commands.MinimizeWindowCommand   MinimizeWindowCommand@  :SecureInfo.Infrastructure.Commands.CloseApplicationCommand  CloseAppCommand=  7SecureInfo.Infrastructure.Commands.MoveWindowAppCommand  MoveWindowCommand@  :SecureInfo.Infrastructure.Commands.EnlargeWindowAppCommand  MaximizeWindowCommand=  7SecureInfo.Infrastructure.Commands.LocalizationCommands  SetLocalCommandA  ;SecureInfo.Infrastructure.Commands.DefaultWindowSizeCommand  DefaultWindowSizeCommand��%�   &	        &	      &	 &     &	 9     &	 L     &	 _       5   
   6$     5   
   6&     5   
   6#     5   
   6&     5   
   6#     5   
   6'   5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5    
   	   CaptionHeight$	 0Q�6   .��5#      �   BackgroundGragient#��[ 6   
 � RowDefinitions
 5%   
   �� 5&      $��50 �6   �� 5'      $��80 �6   �� 5(      .+�5*   
   3	  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon	  $y�Visible=�6    	  
IconSource$ 
appIco.ico��6.    	  DoubleClickCommand# [ 6F    	  	TrayPopup 5+      � 5,      #��[ 6   .+�5-      ��  �� Orientation$ Vertical=�6!   $��10q�68   .+�5.      �� $��5q�6!     AboutSystemBtn#���  6,   ��6W   �� *AboutSystemCommand+�� 5/      $��5q�6!     SecurityBtn#���  6,   ��6T   �� *SecurityCommand+�� 50      $��5q�6!    	 FirewallBtn#��� 	 6,   ��6T   �� *FirewallCommand+�� 51      $��5q�6!    
 
UpdatesBtn#��� 
 6,   ��6S   �� *UpdateCommand+�� 52      $��5q�6!     HelpBtn#���  6,   ��6P   �� *HelpCommand+53      54      56      � 57   
   $��0��6   #��[ 6    J� InputBindings 58      d� 59       d� Gesture$ 	LeftClicka�6    �� Command# [ 63    � ColumnDefinitions 5;      �� 5<      �� 5=      $	��140 �6#   .+�5?      �� $��0��6   $��SecurityInfo��6(     Title_Style#��[ 6<   $��25(�6a   $��DemiBold"�6o   �� 5@      $ 
Horizontal=�6   $��1��62   .+�5A      ��   MinimizeWindowStyle#��[ 6   #��[  6F   $��
10 10 0 10q�6w   �� 5B        MaximizeWindowStyle#��[ 6   #��[ 6F   $��10q�6w   �� 5C        ExitApp#��[ 6   #��[ 6:   5D      5G      �� 5H   
   $��1��6   $ 
Horizontal=�6"   $
��30,0q�6;   .+�5I      �� #���  6     RoundedButtonStyle#��[ 6A   ��6m   �� *AboutSystemCommand+�� 5J      #���  6   #��[ 6B   ��6n   �� *SecurityCommand+�� 5K      #��� 	 6   $	��220��6>   #��[ 6K   ��6w   �� *FirewallCommand+�� 5L      #��� 
 6   #��[ 6@   ��6l   �� *UpdateCommand+�� 5M      #���  6   #��[ 6;   ��6g   �� *HelpCommand+�� 5N      -   5         ��Name$ Localize��5N       �� SelectedIndex$ 1��6)    " MaterialDesignOutlinedComboBox#��[ 5O      $	��100��5P      $��55��6#   
�������$��18(�5Q      ���#088AA8$��Right=�5S      $��60 0 0 0q�63   .
  (System.Windows.Interactivity.Interaction 
  Triggers 5T      /  )System.Windows.Interactivity.EventTrigger  5U         	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5V      6  0System.Windows.Interactivity.InvokeCommandAction     Command# [ 6u      CommandParameter 60   ��  �� ElementName$ Localize�� �� Path$ SelectedItem�6u   5W      .@�5Y      �� -   5        $	��ukr��5Y      $��30��6*   .��5Z      �� $	��Ukr��6      Description_Style#��[ 6+   $��0q�6V   5[      �� 5\      -   5        $	��eng��5\      $��30��6*   .��5]      �� $	��Eng��6    #��[ 6+   $��0q�6V   5^      5_      5`      � 5a   
   $��2��6   .+�5b      �� ��6   �� *CurrentView+5c      5d      5e      