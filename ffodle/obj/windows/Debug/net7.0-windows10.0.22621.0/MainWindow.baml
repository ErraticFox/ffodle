   M S B A M L   `   `   `  ����Y  UMaterial.Icons.WPF, Version=1.2.0.0, Culture=neutral, PublicKeyToken=34ed5903a64b4509S<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPFMaterial.Icons.WPF  5   	   
 ffodle   ffodle.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   VmaterialIcons<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPF     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��5	   	   $	��800��6    � 
ResizeMode$ NoResize=�5
   	    � Icon$ /windows.ico��5   	   
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	   .��5      ��  �� CornerRadius$ 10��6   ���	#FF3A3A46._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $
��auto �6#   62    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5      � $��1��6   $��Right=�6#    5      �� 5      $
��auto �6'   66   �� 5       $
��auto �6'   66   �� 5!      $
��auto �6'   66   .+�5$      �� -   5        $��MinimizeBtn��5$      $��1��6,   $
��🗕��6<   
�������   	minMaxBtn#��[  6w   �� 5&      -   5        $��CloseBtn��5&      $��2��6)   $	��✕��69   
�������  closeButton#��[ 6p   5'      �� 5)      -   5        $��DragBar��5)      ���	#000000006E   �� 5+      -   5         ��Name$ 
urlTextBox��5+      $��1��6*   	 �� TextWrapping$
	 Wrap=�67     urlBoxStyle#��[ 6K   �� 5-      $��1��6   $��1��6)   $��Center=�66   
 �� Orientation$
 
Horizontal=�6Q   $��Center=�6j   .+�51      �� -   5         ��Name$ folderButton��51   3     UrlBarButtons#��[ 6I   .��52      %   Material.Icons.WPF.MaterialIcon  
�������   Kind$ Folder=�6H   53      �� 54      -   5        $ downloadButton��54   0   #��[ 6I   .��55        
�������$ Download=�6H   56      57      �� 59      $��0��6   $��2��6)   $��10, 0q�66   .+�5:      �� $��Output Stream��6   $��16(�60   
�������$��0,0,0,10q�6Q   �� 5;      $ 3��6   ���	#FF484858._�5<      �� $	��250��6#   $	��250��60   $��Disabled=�6A   $��Disabled=�6j   .��5=      �� -   5        $ textBlockStream��5=   �   $	 WrapWithOverflow=�6z    �� 
IsReadOnly$
 True��6�   
�������
������ $��0q�6�   $��10q�6  ��6"   ��  �� Path$ 
StreamText� �� Mode$ OneWay=�6  5>      5?      � 5@      $��0,5,0,0q�6"     progressBarStyle#��[ 6g    � Value 63   �� $ ProgressPercent�$ OneWay=�6g   5A      5C      5D      5E      