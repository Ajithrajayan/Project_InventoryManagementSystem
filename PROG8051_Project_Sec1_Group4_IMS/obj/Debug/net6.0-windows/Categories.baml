   M S B A M L   `   `   `  ����[  WPROG8051_Project_Sec1_Group4_IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PROG8051_Project_Sec1_Group4_IMS PROG8051_Project_Sec1_Group4_IMS  5   	   1    +PROG8051_Project_Sec1_Group4_IMS.Categories   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PROG8051_Project_Sec1_Group4_IMS     5   	     � WindowState$  	Maximized=�5   	    � Title$! Inventory Management System��5	   	   $	��800��6-   $	��800��6:   .��5
      � ���	#FFE1FFFE$��
0,0,-651,0q�6#   $	��784��67   $	��Top=�6D    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    .+�5      o� .@�5      m� -   5         m�Name$ 	dashboard��5      $�� DASHBOARD ��6.   6D   m� 5      -   5        $ 
categories��5      $�� CATEGORIES ��6/   6F   m� 5      -   5        $ products��5      $��
 PRODUCTS ��6-   6A   m� 5      -   5        $ customer��5      $��
 CUSTOMER ��6-   6B   m� 5      -   5        $ order��5      $�� ORDER ��6*   6<   m� 5      -   5        $ employee��5      $��
 EMPLOYEE ��6-   6B   5       � 5      -   5          �Name$ 	mainFrame��5      $��1��6'   5      � 5   
    5       �� 5!      $��50 �6    �� 5"      $��40 �6    .+�5$      �� -   5         ��Name$ Label_login��5$   8   $��	0,45,0,-5q�6   $��2��6'   $��						CATEGORY��6M   $��Britannic Bold)�6~   $��24(�6�   $
��Bold"�6�   5%      �� 5'   
   -	   5        $ Label_ID��5'      $��ID��6"   $
��Left=�6/   $��188,140,0,0q�6J   $	��Top=�6_   $��26��6w   $��22��6�   �� 5(   
   -
   5        $ Label_Cname��5(      $��Category_Name��6%   $
��Left=�6=   $��188,180,0,0q�6X   $	��Top=�6m   $��26��6�   $��97��6�   �� 5*   
   -   5         ��Name$ 
TextBox_ID��5*      $
��Left=�6'    �� 
IsReadOnly$
 True��6B   $��340,132,0,0q�6T   	 �� TextWrapping$
	 Wrap=�6i   $	��Top=�6}   $	��273��6�   $��36��6�   �� 5+   
   -   5        $ TextBox_CName��5+      $
��Left=�6*   $��340,172,0,0q�6E   $
	 Wrap=�6Z   $	��Top=�6n   $	��273��6�   $��36��6�   &   System.Windows.Controls.DataGrid  5-   
   -   5        
  Name$
 DataGrid_CategoryDetails��5-         
IsReadOnly$
 True��65      AutoGenerateColumns$ False��6G   $
��Left=�6c   $��726,132,0,0q�6~   $	��Top=�6�   $	��465��6�   $	��453��6�    � 	Resources 5.      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5/      "  6   .�50      ��  � ��
 ���@�63   �� 51       � ��$ 0,0,1,2q�68   �� 52       � ��
 �   �64   53      54         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$  Category ID ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Category_ID+6\     57      $  Category Name ��6%   $ * 6`    6>   �� *Category_Name+6`   5:        5;   
   -   5        $$
 DataGrid_Category_Product_List��5;      $
 True��6;   $ False��6M   $
��Left=�6i   $��188,300,0,0q�6�   $	��Top=�6�   $	��474��6�   $	��349��6�    5<      ��%�   '        �� 5=      "  6   .�5>      ��  � ��
 ���@�63   �� 5?       � ��$ 0,0,1,2q�68   �� 5@       � ��
 �   �64   5A      5B       5C        5D      $  Product ID ��6%   $ * 6Z    6;   �� *
Product_ID+6Z     5E      $  Product Name ��6%   $ * 6^    6=   �� *Product_Name+6^     5F      $  Unit Price ��6%   $ * 6Z    6;   �� *
Unit_Price+6Z     5G      $  QTY ��6%   $ * 6T    64   �� *Product_QTY+6T   5J      �� 5M   
   -   5         ��Name$ Button_Category_ADD��5M      $	��ADD��6/   $
��Left=�6=   $��340,220,0,0q�6X   $	��Top=�6m   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  �� 5N   
   -   5        $ Button_Category_Update��5N      $��UPDATE��62   $
��Left=�6C   $��740,600,0,0q�6^   $	��Top=�6s   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  �� 5O   
   -   5        $ Button_Category_Delete��5O      $��DELETE��62   $
��Left=�6C   $��900,600,0,0q�6^   $	��Top=�6s   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $��2��6  5P      5Q      