   M S B A M L   `   `   `  ����   dentalConnectWPF,    &dentalConnectWPF.Functions.winCategory   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  MenuView��$	��750��$
��1000�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Icon$ /Logos/aplicacion.png��.����  �� CornerRadius$ 12��._��� $ 10��$��2q� J� Opacity$
 0.95Q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #32403B�� � Offset$ 0Q�� $
 #C9FFEB��$
 0.75Q�� $
 #7C9C90��$ 1Q����� $	 0,1&�$		 1,0&�.��� $
 #B5E6D4��$ 0Q�� $
 #658076��$ 1Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��
CATEGORIAS��
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
 �  ������ " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��/Logos/aplicacion.png��$��51,-19,894,612q�$��2���� $��
CATEGORIAS�����#32403B$��36(�$
��Bold"�$��
Montserrat)�$
��Left=�$��107,7,0,673q�$	��262��$��1���� $��Nombre:�����#32403B$��36(�$��Medium"�$��
Montserrat)�$
��Left=�$��44,90,0,583q�$	��172��$��1���� $��Descripción:�����#32403B$��36(�$��Medium"�$��
Montserrat)�$
��Left=�$��44,161,0,498q�$	��226��$��1���� -    ��Name$ txbName��$
��Left=�$��
281,93,0,0q�$��1��$	��Top=�$	��232��$��38��$��24(�
��������� -   $ 
txbDescrip��$
��Left=�$��281,161,0,0q�$��1��$	��Top=�$	��232��$��38��$��24(�
��������� -   $ 	btnInsert��$	��➕��$
��Left=�$��688,129,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF386591���	#FF386591�� -   $ btnSave��$
��💾��$
��Left=�$��
688,98,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF3C7861���	#FF2A5746�� -   $ 	btnCancel��$	��❌��$
��Left=�$��688,160,0,0q�$��1��$	��Top=�$	��146��$��44��$��24(����	#FF3C6162���	#FF314E4F&   System.Windows.Controls.DataGrid  -	     Name$ dgDatos��$��1��$��51,301,162,68q�
������    CanUserAddRows .     
IsReadOnly . �� -
    ��Name$ 
txtMessage��$
��Left=�$��
51,232,0,0q�$��1��$
��Wrap=�$	��Top=�$	��580��$��50��$��22(��� -   $ btnMenu��$��0q�$��<-��
�������$��12(�$��
Montserrat)�$
 Hand��$��	5,0,966,0q����� " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 � d ����� " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ snackbar��$��67��$	��Top=�$	��607��$��
369,24,0,0q�$
��Left=�$��18(�$��Normal"�$��2��   MessageQueue 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� -   $ btn_help_name��$�� ��$
��Left=�$��520,100,0,0q�$��1��$	��Top=�$��24��$��26�� J� RenderTransformOrigin$ -0.231,0.48&�$
 Hand����Z� ����  �� ImageSource$ /Logos/help.png���� -   $ btn_help_Descr��$�� ��$
��Left=�$��520,168,0,0q�$��1��$	��Top=�$��24��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $ /Logos/help.png��