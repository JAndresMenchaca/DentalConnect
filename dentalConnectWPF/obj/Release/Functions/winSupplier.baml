   M S B A M L   `   `   `  ����   dentalConnectWPF,    &dentalConnectWPF.Functions.winSupplier   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  MenuView��$	��750��$
��1300�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Icon$ /Logos/camion.png��.����  �� CornerRadius$ 12��._��� $ 10��$��2q� J� Opacity$
 0.95Q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #32403B�� � Offset$ 0Q�� $
 #C9FFEB��$
 0.75Q�� $
 #7C9C90��$ 1Q����� $	 0,1&�$		 1,0&�.��� $
 #B5E6D4��$ 0Q�� $
 #658076��$ 1Q�._��  � RowDefinitions �� $��30 ��� .+�� $��0�� � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��PROVEEDORES��
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
 �  ������ " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��/Logos/camion.png��$��
51,0,0,665q�$��53��$��Bottom=�$
��Left=�$��51��$��2���� $��PROVEEDORES�����#32403B$��36(�$
��Bold"�$��
Montserrat)�$
��Left=�$��114,8,0,665q�$	��318��$��1���� $��Nombre:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��45,118,0,566q�$	��132��$��1��&   System.Windows.Controls.DataGrid  -     Name$ dgDatos��$��1��$��45,381,58,27q�
������    CanUserAddRows .     
IsReadOnly . �� -    ��Name$ 
txtMessage��$
��Left=�$��
51,334,0,0q�$��1��$
��Wrap=�$	��Top=�$	��818��$��28��$��20(��� -   $ btnMenu��$��0q�$��<-��
�������$��12(�$��
Montserrat)�$
 Hand��$��5,0,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�$��30��$��Center=�$
��Left=�$��23��z�V� .~��� ��  �� AngleY$ -1.128Q��� T�  T� Y$ -1.23Q����� " ��.���  � �� �#658076 P�  �@J�IsMouseOver . . ���  � ��
 � d ����� " ��.R��� $��18��$��18��$ 9��#��z��._��� $��Center=�$��Center=��� $��
Teléfono:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��45,170,0,514q�$	��136��$��1���� $��Email:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��45,223,0,461q�$	��121��$��1���� $��
Sitio Web:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��45,276,0,408q�$	��148��$��1���� $��Calle Adyacente:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��463,225,0,459q�$	��239��$��1���� $��Calle Principal:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��465,169,0,515q�$	��212��$��1���� $��Ciudad:�����#32403B$��28(�$��Medium"�$��
Montserrat)�$
��Left=�$��465,117,0,567q�$	��122��$��1���� -    ��Name$ txbPhone��$
��Left=�$��193,154,0,0q�$��1�� �� TextWrapping$ NoWrap=�$	��Top=�$	��215��$��44��$��24(�
�������  K� ZIndex$  2��$��Medium"��� -   $ txbEmail��$
��Left=�$��193,209,0,0q�$��1��$ NoWrap=�$	��Top=�$	��215��$��43��$��24(�
�������$  3��$��Medium"��� -	   $ txbWeb��$
��Left=�$��193,267,0,0q�$��1��$ NoWrap=�$	��Top=�$	��215��$��43��$��24(�
�������$  4��$��Medium"��� -
   $ txbMain��$
��Left=�$��707,153,0,0q�$��1��$ NoWrap=�$	��Top=�$	��241��$��44��$��24(�
�������$  6��$��Medium"��� -   $ txbAd��$
��Left=�$��707,213,0,0q�$��1��$ NoWrap=�$	��Top=�$	��242��$��43��$��24(�
�������$  7��$��Medium"��� -   ! ��Name$! cbCity��$
��Left=�$��707,102,0,0q�$��1��$	��Top=�$	��241��$��24(�$  5��$��43���� -   $ btn_help_name��$�� ��$
��Left=�$��414,118,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� " �� ImageSource$" /Logos/help.png���� -   $ btn_help_phone��$�� ��$
��Left=�$��414,170,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png���� -   $ btn_help_email��$�� ��$
��Left=�$��414,222,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png���� -   $ btn_help_web��$�� ��$
��Left=�$��414,279,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png���� -   $ btn_help_main��$�� ��$
��Left=�$��957,170,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png���� -   $ btn_help_ad��$�� ��$
��Left=�$��957,229,0,0q�$��1��$	��Top=�$��25��$��26��$ -0.231,0.48&�$
 Hand����Z� ���� $" /Logos/help.png��'  !MaterialDesignThemes.Wpf.Snackbar  -   #  Name$# snackbar��$��90��$	��Top=�$	��590��$��
460,10,0,0q�$
��Left=�$��18(�$��Normal"�$��2��$   MessageQueue$ 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� -   $ txbName��$
��Left=�$��193,108,0,0q�$��1��$ NoWrap=�$	��Top=�$	��216��$��43��$��24(�
�������$  1��$��Medium"��� -   $ 	btnInsert��$	��➕��$
��Left=�$��1045,151,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF386591���	#FF386591�� -   $ btnSave��$
��💾��$
��Left=�$��1045,120,0,0q�$��1��$	��Top=�$	��146��$��24(�$��44�����	#FF3C7861���	#FF2A5746�� -   $ 	btnCancel��$	��❌��$
��Left=�$��1045,182,0,0q�$��1��$	��Top=�$	��146��$��44��$��24(����	#FF3C6162���	#FF314E4F