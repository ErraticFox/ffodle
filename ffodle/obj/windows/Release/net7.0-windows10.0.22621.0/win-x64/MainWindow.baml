   M S B A M L   `   `   `  ���� Y  UMaterial.Icons.WPF, Version=1.2.0.0, Culture=neutral, PublicKeyToken=34ed5903a64b4509S<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPFMaterial.Icons.WPF  
 ffodle   ffodle.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     VmaterialIcons<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPF     -     � Title$  
MainWindow��$	��450��$	��800�� � 
ResizeMode$ NoResize=� � Icon$ /windows.ico��
������  � AllowsTransparency$
 True�� � WindowStyle$
 None=�.����  �� CornerRadius$ 10�����	#FF3A3A46._��  � ColumnDefinitions �� $��* ��� $
��auto � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��1��$��Right=� �� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��MinimizeBtn��$��1��$
��🗕��
�������   	minMaxBtn#��[  �� -   $��CloseBtn��$��2��$	��✕��
�������  closeButton#��[ �� -   $��DragBar�����	#00000000�� -    ��Name$ 
urlTextBox��$��1��	 �� TextWrapping$
	 Wrap=�  urlBoxStyle#��[ �� $��1��$��1��$��Center=�
 �� Orientation$
 
Horizontal=�$��Center=�.+��� -    ��Name$ folderButton��  UrlBarButtons#��[ .��%   Material.Icons.WPF.MaterialIcon  
�������   Kind$ Folder=��� -   $ downloadButton��#��[ .��  
�������$ Download=��� $��0��$��2��$��10, 0q�.+��� $��Output Stream��$��16(�
�������$��0,0,0,10q��� $ 3�����	#FF484858._��� $	��250��$	��250��$��Disabled=�$��Disabled=�.���� -   $ textBlockStream��$	 WrapWithOverflow=� �� 
IsReadOnly$
 True��
�������
������ $��0q�$��10q�����  �� Path$ 
StreamText� �� Mode$ OneWay=�� $��0,5,0,0q�  progressBarStyle#��[  � Value �� $ ProgressPercent�$ OneWay=�