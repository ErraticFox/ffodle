   M S B A M L   `   `   `  ����A  =ffodle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffodleffodle  5   	       ffodle.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ffodle     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��5
   	   $	��800��6    � 
ResizeMode$ NoResize=�6"    � WindowStyle$
 None=�68    � Icon$ /windows.ico��6K    � Topmost$
 True��6_   .��5      �  � ShowGridLines$
 True��6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $	��100 �6   6-    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   � $��1��6    5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� 
������ $��0q�6.   $��5q�6B   $��_��6M   $��0��6Y   $��Center=�6i   �� 5      
������ $��0q�6.   $��5q�6B   $
��🗖��6M   $��1��6Z   �� 5       -   5        
������ $��0q�5    B   $��5q�6V   $	��✕��6a   $��2��6m   5!      o� 5#   
   $y�Hidden=�6   5$      �� 5&   
   -   5         ��Name$ 
urlTextBox��5&   '   $��10,22,10,23q�6   $��0��6;   $��1��6K   	 �� TextWrapping$
	 Wrap=�6X   ��6l   �� *url+�� 5(   
   $��1��6   $��1��6%   $��10q�62   .+�5)      �� -   5        
 ��Name$
 outputFolderBtn��5)   E   $��0 0 0 10q�63   $��Output��6^   �� 5*      -   5        $
 downloadButton��5*   2   $��Download��6J   5+      �� 5,   
   -   5         ��Name$ outputStream��5,      $��1��6*   $��2��6:   ��6G   �� *Url+ �� Mode$ TwoWay=�5-      5.      