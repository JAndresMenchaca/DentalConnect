   M S B A M L   `   `   `  ����   dentalConnectWPF+    %dentalConnectWPF.Functions.winProduct   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  MenuView��$	��750��$
��1300�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Icon$ /Logos/producto.png��.����  �� CornerRadius$ 12��._��� $ 10��$��2q� J� Opacity$
 0.95Q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #32403B�� � Offset$ 0Q�� $
 #C9FFEB��$
 0.75Q�� $
 #7C9C90��$ 1Q����� $	 0,1&�$		 1,0&�.��� $
 #B5E6D4��$ 0Q�� $
 #658076��$ 1Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��	PRODUCTOS��
�������$��18(�$��
Montserrat)�$��0��$��Center=�$��	30,0,17,0q�$
��Bold"��� -    ��Name$ btnMinimize��$��0q�$��-��
�������$��16(�$��
Montserrat)� � Cursor$
 Hand��$��1������  �� 
TargetType" ��.���  �� Property � �� �� Value �#7C9C90 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 � �������  �� 
TargetType" ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� -   $ btnClose��$��0q�$��X��
�������$��12(�$��
Montserrat)�$
 Hand��$��2������ " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 �  ������ " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��/Logos/producto.png��$��
54,0,0,661q�$��54��$��Bottom=�$
��Left=�$��47�� J� RenderTransformOrigin$ 
0.02,0.651&�$��1���� $��	PRODUCTOS�����#32403B$��48(�$
��Bold"�$��
Montserrat)�$
��Left=�$��107,5,0,663q�$	��295��$��1���� $��Nombre:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��51,120,0,564q�$	��132��$��1��&   System.Windows.Controls.DataGrid  -     Name$ dgDatos��$��1��$��51,381,109,27q�
������    CanUserAddRows .     
IsReadOnly . �� -    ��Name$ 
txtMessage��$
��Left=�$��
51,339,0,0q�$��1��$
��Wrap=�$	��Top=�$	��818��$��42��$��20(��� -   $ btnMenu��$��0q�$��<-��
�������$��12(�$��
Montserrat)�$
 Hand��$��5,0,0,0q�$ 0.5,0.5&�$��30��$	��Top=�$
��Left=�$��23��z�V� .~��� ��  �� AngleY$ -1.128Q��� T�  T� Y$ -1.23Q����� " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 � d ����� " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��Descripción:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��51,172,0,512q�$	��209��$��1���� $��Precio (Bs.):�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��51,224,0,460q�$	��169��$��1���� $��Stock:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��51,278,0,406q�$	��148��$��1���� $��
Proveedor:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��510,167,0,517q�$	��212��$��1���� $��Categoría:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��510,115,0,569q�$	��150��$��1���� -    ��Name$ txbDesc��$
��Left=�$��231,156,0,0q�$��1�� �� TextWrapping$ NoWrap=�$	��Top=�$	��215��$��44��$��24(�
�������  K� ZIndex$  2��$��Medium"��� -   $ txbPrice��$
��Left=�$��231,210,0,0q�$��1��$ NoWrap=�$	��Top=�$	��215��$��44��$��24(�
�������$  3��$��Medium"��� -	   $ txbStock��$
��Left=�$��231,268,0,0q�$��1��$ NoWrap=�$	��Top=�$	��215��$��44��$��24(�
�������$  4��$��Medium"��� -
   ! ��Name$! cbCateg��$
��Left=�$��680,100,0,0q�$��1��$	��Top=�$	��322��$��24(�$  5��$��43���� -   $ btn_help_name��$�� ��$
��Left=�$��452,122,0,0q�$��1��$	��Top=�$��26��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� " �� ImageSource$" /Logos/help.png���� -   $ btn_help_desc��$�� ��$
��Left=�$��452,172,0,0q�$��1��$	��Top=�$��24��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png���� -   $ btn_help_price��$�� ��$
��Left=�$��452,224,0,0q�$��1��$	��Top=�$��26��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png���� -   $ btn_help_stock��$�� ��$
��Left=�$��452,284,0,0q�$��1��$	��Top=�$��24��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png��'  !MaterialDesignThemes.Wpf.Snackbar  -   #  Name$# snackbar��$��90��$	��Top=�$	��590��$��
460,10,0,0q�$
��Left=�$��18(�$��Normal"�$��2��$   MessageQueue$ 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� -   $ txbName��$
��Left=�$��231,110,0,0q�$��1��$ NoWrap=�$	��Top=�$	��216��$��42��$��24(�
�������$  1��$��Medium"��� -   $! 
cbSupplier��$
��Left=�$��680,158,0,0q�$��1��$	��Top=�$	��322��$��24(�$  6��$��43���� -   $ 	btnInsert��$	��➕��$
��Left=�$��1041,147,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF386591���	#FF386591�� -   $ btnSave��$
��💾��$
��Left=�$��1041,116,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF3C7861���	#FF2A5746�� -   $ 	btnCancel��$	��❌��$
��Left=�$��1041,178,0,0q�$��1��$	��Top=�$	��146��$��44��$��24(����	#FF3C6162���	#FF314E4F