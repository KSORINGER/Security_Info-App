   M S B A M L   `   `   `  ���� E  ASecureInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SecureInfo
SecureInfo  =#clr-namespace:SecureInfo.ViewModelsSecureInfo.ViewModels  W0clr-namespace:SecureInfo.Infrastructure.Commands"SecureInfo.Infrastructure.Commands  !    SecureInfo.Views.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:SecureInfo     2vm#clr-namespace:SecureInfo.ViewModels     @cmd0clr-namespace:SecureInfo.Infrastructure.Commands     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  _ [Hardcodet.NotifyIcon.Wpf, Version=1.1.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar    � WindowStyle$
  None=� � AllowsTransparency . 
������ 
������  � Icon$ 
appIco.ico�� � 
ResizeMode$ 	CanResize=� � WindowStartupLocation$ CenterScreen=� � Title$ 
MainWindow��$	��700��$
��1200�� � DataContext /  )SecureInfo.ViewModels.MainWindowViewModel   � 	Resources >  8SecureInfo.Infrastructure.Commands.MinimizeWindowCommand   MinimizeWindowCommand@  :SecureInfo.Infrastructure.Commands.CloseApplicationCommand  CloseAppCommand=  7SecureInfo.Infrastructure.Commands.MoveWindowAppCommand  MoveWindowCommand@  :SecureInfo.Infrastructure.Commands.EnlargeWindowAppCommand  MaximizeWindowCommand=  7SecureInfo.Infrastructure.Commands.LocalizationCommands  SetLocalCommandA  ;SecureInfo.Infrastructure.Commands.DefaultWindowSizeCommand  DefaultWindowSizeCommand��%Z   &	        &	      &	 
     &	      &	      &	                  '  !System.Windows.Shell.WindowChrome   WindowChrome   	   CaptionHeight$	 0Q�.���   BackgroundGragient#��[ 
 � RowDefinitions
 �� $��50 ��� $��80 ��� .+�3	  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon	  $y�Visible=� 	  
IconSource$ 
appIco.ico�� 	  DoubleClickCommand# [  	  	TrayPopup � #��[ .+���  �� Orientation$ Vertical=�$��10q�.+��� $��5q�  AboutSystemBtn#���  ���� *AboutSystemCommand+�� $��5q�  SecurityBtn#���  ���� *SecurityCommand+�� $��5q� 	 FirewallBtn#��� 	 ���� *FirewallCommand+�� $��5q� 
 
UpdatesBtn#��� 
 ���� *UpdateCommand+�� $��5q�  HelpBtn#���  ���� *HelpCommand+� $��0��#��[  J� InputBindings d�  d� Gesture$ 	LeftClicka� �� Command# [  � ColumnDefinitions �� �� $	��140 �.+��� $��0��$��SecurityInfo��  Title_Style#��[ $��25(�$��DemiBold"��� $ 
Horizontal=�$��1��.+���   MinimizeWindowStyle#��[ #��[  $��
10 10 0 10q���   MaximizeWindowStyle#��[ #��[ $��10q���   ExitApp#��[ #��[ �� $��1��$ 
Horizontal=�$
��30,0q�.+��� #���    RoundedButtonStyle#��[ ���� *AboutSystemCommand+�� #���  #��[ ���� *SecurityCommand+�� #��� 	 $	��220��#��[ ���� *FirewallCommand+�� #��� 
 #��[ ���� *UpdateCommand+�� #���  #��[ ���� *HelpCommand+�� -    ��Name$ Localize�� �� SelectedIndex$ 1�� " MaterialDesignOutlinedComboBox#��[ $	��100��$��55��
�������$��18(����#088AA8$��Right=�$��60 0 0 0q�.
  (System.Windows.Interactivity.Interaction 
  Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command# [    CommandParameter ��  �� ElementName$ Localize�� �� Path$ SelectedItem�.@��� -   $	��ukr��$��30��.���� $	��Ukr��  Description_Style#��[ $��0q��� -   $	��eng��$��30��.���� $	��Eng��#��[ $��0q�� $��2��.+��� ���� *CurrentView+