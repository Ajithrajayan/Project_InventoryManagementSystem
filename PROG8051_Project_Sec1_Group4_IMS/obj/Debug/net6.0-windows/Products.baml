   M S B A M L   `   `   `  ����[  WPROG8051_Project_Sec1_Group4_IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PROG8051_Project_Sec1_Group4_IMS PROG8051_Project_Sec1_Group4_IMS  5   	   /    )PROG8051_Project_Sec1_Group4_IMS.Products   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PROG8051_Project_Sec1_Group4_IMS     5   	     � WindowState$  	Maximized=�5   	    � Title$! Inventory Management System��5	   	   $	��800��6-   $	��800��6:   .��5
      � ���	#FFE1FFFE$��
0,0,-651,0q�6#   $	��784��67   $	��Top=�6D    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    .+�5      o� .@�5      m� -   5         m�Name$ 	dashboard��5      $�� DASHBOARD ��6.   6D   m� 5      -   5        $ 
categories��5      $�� CATEGORIES ��6/   6F   m� 5      -   5        $ products��5      $��
 PRODUCTS ��6-   6A   m� 5      -   5        $ customer��5      $��
 CUSTOMER ��6-   6B   m� 5      -   5        $ order��5      $�� ORDER ��6*   6<   m� 5      -   5        $ employee��5      $��
 EMPLOYEE ��6-   6B   5       � 5      -   5          �Name$ 	mainFrame��5      $��1��6'   5      � 5   
    5      �� 5       $��50 �6    �� 5!      $��40 �6    .+�5#      �� -   5         ��Name$ Label_login��5#   8   $��	0,45,0,-5q�6   $��2��6'   $��						PRODCUTS��6M   $��Britannic Bold)�6~   $��24(�6�   $
��Bold"�6�   5$      �� 5&   
   -	   5        $ Label_Category��5&      $��Category��6(   $
��Left=�6;   $��
80,140,0,0q�6V   $	��Top=�6j   $��26��6�   $��80��6�   �� 5'   
   -
   5        $ 
Label_Name��5'      $
��Name��6$   $
��Left=�63   $��
80,180,0,0q�6N   $	��Top=�6b   $��26��6z   $��97��6�   �� 5(   
   -   5        $ Label_UnitPrice��5(      $��
Unit Price��6)   $
��Left=�6>   $��
80,220,0,0q�6Y   $	��Top=�6m   $��26��6�   $��80��6�   �� 5)   
   -   5        $ Label_Quantity��5)      $��Quantity��6(   $
��Left=�6;   $��
80,260,0,0q�6V   $	��Top=�6j   $��26��6�   $	��110��6�   �� 5+   
   -   5         ��Name$ ComboBox_Category��5+      $
��Left=�6/   $��240,132,0,0q�6J    �� DisplayMemberPath$ CategoryName��6_   $	��Top=�6�   $	��273��6�   $��36��6�   6�   �� 5,   
   -   5        	 ��Name$	 TextBox_Name��5,      $
��Left=�6)   $��240,172,0,0q�6D   
 �� TextWrapping$

 Wrap=�6Y   $	��Top=�6m   $	��273��6�   $��36��6�   �� 5-   
   -   5        $	 TextBox_UnitPrice��5-      $
��Left=�6.   $��240,212,0,0q�6I   $

 Wrap=�6^   $	��Top=�6r   $	��273��6�   $��36��6�   �� 5.   
   -   5        $	 TextBox_Quantity��5.      $
��Left=�6-   $��240,252,0,0q�6H   $

 Wrap=�6]   $	��Top=�6q   $	��273��6�   $��36��6�   �� 5/   
   -   5        $	 TextBox_Search��5/      $y�Hidden=�6+   $
��Left=�6?   $��800,125,0,0q�6Z   $

 Wrap=�6o   $	��Top=�6�   $	��250��6�   $��47��6�   �� 51   
   -   5         ��Name$ Button_Product_Add��51      $	��ADD��6.   $
��Left=�6<   $��240,350,0,0q�6W   $	��Top=�6l   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ DataGrid_Product_Details��52         
IsReadOnly$
 True��65      AutoGenerateColumns$ False��6G   $
��Left=�6c   $��580,180,0,0q�6~   $	��Top=�6�   $	��643��6�   $	��392��6�    � 	Resources 54      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 55      "  6   .�56      ��  � ��
 ���@�63   �� 57       � ��$ 0,0,1,2q�68   �� 58       � ��
 �   �64   59      5:         Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$	  ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 10 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
Product_ID+6Q     5=      $  Product Name��6%   $ * 6]    6<   �� *Product_Name+6]     5>      $  Unit Price ��6%   $ * 6Z    6;   �� *
Unit_Price+6Z     5?      $  QTY ��6%   $ * 6U    65   �� *Product_QTY+6U     5@      $  Category ID��6%   $ * 6\    6<   �� *Category_ID+6\   5D      �� 5E   
   -   5        $ Button_Product_Update��5E      $��UPDATE��61   $
��Left=�6B   $��580,600,0,0q�6]   $	��Top=�6r   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6
  $��2��6  �� 5F   
   -   5        $ Button_Product_Delete��5F      $��DELETE��61   $
��Left=�6B   $��740,600,0,0q�6]   $	��Top=�6r   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6
  $��2��6  �� 5G   
   -   5        $ Button_Product_Search��5G      $y�Hidden=�61   $��SEARCH��6E   $
��Left=�6V   $��1080,125,0,0q�6q   $	��Top=�6�   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6�   5H      5I      