   M S B A M L   `   `   `  ����[  WPROG8051_Project_Sec1_Group4_IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PROG8051_Project_Sec1_Group4_IMS PROG8051_Project_Sec1_Group4_IMS  5   	   -    'PROG8051_Project_Sec1_Group4_IMS.Orders   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PROG8051_Project_Sec1_Group4_IMS     5   	     � WindowState$  	Maximized=�5	   	    � Title$ Orders��5
   	   $	��800��6   $	��800��6%    � 	Resources 5      6   0PROG8051_Project_Sec1_Group4_IMS.AmountConverter   AmountConverter��%   &	          5   
   6    5      .��5      � ���	#FFE1FFFE$��
0,0,-651,0q�6#   $	��784��67   $	��Top=�6D    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    .+�5      o� .@�5      m� -   5         m�Name$ 	dashboard��5      $�� DASHBOARD ��6.   6D   m� 5      -   5        $ 
categories��5      $�� CATEGORIES ��6/   6F   m� 5      -   5        $ products��5      $��
 PRODUCTS ��6-   6A   m� 5      -   5        $ customer��5      $��
 CUSTOMER ��6-   6B   m� 5      -   5        $ order��5      $�� ORDER ��6*   6<   m� 5      -   5        $ employee��5      $��
 EMPLOYEE ��6-   6B   5        � 5!      -   5          �Name$ 	mainFrame��5!      $��1��6'   5"      � 5#   
   $��
0,-10,0,10q�6    5$      �� 5%      $��50 �6    �� 5&      $��40 �6    .+�5(      �� -   5         ��Name$ Label_login��5(   '   $��	0,0,0,-10q�6   $0��*				                                ORDERS��6<   $��Britannic Bold)�6�   $��24(�6�   $
��Bold"�6�   $��1��6�   5+      �� 5.   
   $��Customer ID��6   $
��Left=�6&   $��
80,140,0,0q�6A   $	��Top=�6U   $��26��6m   $��80��6y   �� 5/   
   $��Customer Name��6   $
��Left=�6(   $��
80,180,0,0q�6C   $	��Top=�6W   $��26��6o   $��97��6{   �� 50   
   $��Total Amount��6   $
��Left=�6'   $��900,560,0,0q�6B   $	��Top=�6W   $��26��6o   $��98��6{    J� RenderTransformOrigin$ 0.755,0.444&�6�   �� 53   
   -	   5        	 ��Name$	 TextBox_Customer_ID��53      
 �� 
IsReadOnly$

 True��60   $
��Left=�6B   $��240,132,0,0q�6]    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��273��6�   $��36��6�   6�   �� 54   
   -
   5        $	 TextBox_Customer_Name��54      $

 True��62   $
��Left=�6D   $��240,172,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $	��273��6�   $��36��6�   �� 55   
   -   5        $	 TextBox_Total_Amount��55      $

 True��61   $
��Left=�6C   $��1000,560,0,0q�6^   $
 Wrap=�6t   $	��Top=�6�   $	��273��6�   $��36��6�   �� 58   
   -   5         ��Name$ Button_Product_Add��58      $��ADD PRODUCT��6.   $
��Left=�6D   $��400,399,0,0q�6_   $	��Top=�6t   $��46��6�   $	��160��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6	  &   System.Windows.Controls.DataGrid  59   
   -   5          Name$ DataGrid_ProductList��59         AutoGenerateColumns$ False��61      
IsReadOnly$
 True��6M   $
��Left=�6_   $��
40,312,0,0q�6z   $	��Top=�6�   $	��336��6�   $	��335��6�    5:      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5;      "  6   .�5<      ��  � ��
 ���@�63   �� 5=       � ��$ 0,0,1,2q�68   �� 5>       � ��
 �   �64   5?      5@         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$
  ID ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
Product_ID+6S     5C      $  Product Name ��6%   $ * 6^    6=   �� *Product_Name+6^     5D      $  Unit Price ��6%   $ * 6Z    6;   �� *
Unit_Price+6Z     5E      $  Stock ��6%   $ * 6V    66   �� *Product_QTY+6V   5H        5I   
   -   5        $ DataGrid_OrderData��5I      $
 True��6/   $ False��6A   $
��Left=�6^   $��587,250,0,0q�6y   $	��Top=�6�   $	��681��6�   $	��296��6�    5J      ��%�   '        �� 5K      "  6   .�5L      ��  � ��
 ���@�63   �� 5M       � ��$ 0,0,1,2q�68   �� 5N       � ��
 �   �64   5O      5P       5Q        5R      $  Product ID ��6%   $ * 6S    6;   �� *PID+6S     5S      $  Product Name ��6%   $ * 6W    6=   �� *PName+6W     5T      $  QTY ��6%   $ * 6M    64   �� *PQTY+6M     5U      $  Unit Price ��6%   $ * 6V    6;   �� *Uprice+6V     5V      $  Amount ��6%   $ * 6Q    67   �� *Amout+6Q   5[      �� 5\   
   -   5        $ Button_ConfirmOrder��5\      $��CONFIRM ORDER��6/   $
��Left=�6G   $��1000,600,0,0q�6b   $	��Top=�6x   $��47��6�   $	��185��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  �� 5]   
   -   5        $ Button_Order_Delete��5]      $��DELETE��6/   $
��Left=�6@   $��1125,171,0,0q�6[   $	��Top=�6q   $��47��6�   $	��143��6�   ���	#FF2CCAC1$��Britannic Bold)�6�   $
��Bold"�6�   $��24(�6  $ 1.312,0.782&�6  �� 5^   
   -   5        $ Button_PreviousOrders��5^      $y�Hidden=�61   $��SHOW PREVIOUS ORDERS��6E   $
��Left=�6d   $��650,160,0,0q�6   $	��Top=�6�   $��47��6�   $	��300��6�   ���	#FF2CCAC1$��Britannic Bold)�6  $
��Bold"�6  $��24(�60  �� 5_   
   -   5         ��Name$ customerComboBox��5_      $��23��6/   $	��120��6;   $��-20,80,0,600q�6G    �� DisplayMemberPath$ CustomerName��6]   5a      �� 5b   
   -   5        $ categoryComboBox��5b      $��23��6-   $	��120��69   $��0,111,950,400q�6E   $ CategoryName��6\   5c      �� 5e   
   $��Center=�6   $��Center=�62   .+�5f      � -   5         �Name$ progressBar��5f      $	��200��6/   $��20��6;   $��0,10,0,0q�6G   $y�Hidden=�6Y   5g      5h      5i      