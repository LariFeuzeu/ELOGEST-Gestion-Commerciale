   M S B A M L   `   `   `  ����D  @GES-COM 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GES_COM_2	GES_COM_2  5   	   ;"clr-namespace:GES_COM_2.ViewModelsGES_COM_2.ViewModels  5   	       GES_COM_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GES_COM_2     5   	   1vm"clr-namespace:GES_COM_2.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��720��5
   	   $
��1080��5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � DataContext 5      !  GES_COM_2.ViewModels.MainVM  5   
    � 	Resources 5         RoundButtonStyle �� 
TargetType �� Property �� Value��%�  &	        '�� N    �� 5   
   " ��6)   .�5      ��  � ��$ 10q�6'   �� 5       � ��$ 60��6'   �� 5       � ��$ 60��6&   �� 5       � �� �#3d348b6+   �� 5       � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5       ��  � ��
 ���� 5"      5#      5%      .��5&      �� 
�������	 �� CornerRadius$	 8��5(      ._�5)   
   � 
 � RowDefinitions
 5+      �� 5,      $��50 �6    �� 5-      $��* �6     � ColumnDefinitions 5/      �� 50      $	��228 �6#   �� 51      $��* �6#   .+�53      n� -   5         J� Opacity$ 0Q�53       K� ZIndex$ 1��6    $��6��61   $��2 2 0 0q�6;   $��6��6L   $
��Left=�6W   $	��Top=�6r    � Cursor$ SizeNWSE��6�   
���   �6�   n� 54      -   5        $ 0Q�54      $ 1��6    $��6��61   $��0 2 2 0q�6;   $��6��6L   $��Right=�6W   $	��Top=�6s   $ SizeNESW��6�   
���   �6�   n� 55      -   5        $ 0Q�55      $ 1��6    $��6��61   $��2 0 0 2q�6;   $��6��6L   $
��Left=�6W   $��Bottom=�6r   $ SizeNESW��6�   
���   �6�   n� 56      -   5        $ 0Q�56      $ 1��6    $��6��61   $��0 0 2 2q�6;   $��6��6L   $��Right=�6W   $��Bottom=�6s   $ SizeNWSE��6�   
���   �6�   �� 59      -   5         ��Name$ stackPanelMenu��5;       �� Orientation$ Vertical=�59      $��0��5:      $��1��5<      $��
8,80,10,10q�5>      .+�5@      	� -   5         	�Name$ 
btnAccueil��5@   6   $y�	Collapsed=�6   
 � Tag$	 all��6J   $��Accueil��6w     MenuRadioButtonStyle#���  6�   $��0 5 0 5q�6�   ��6T   �� *AccueilCommand+6�   	� 5A      -   5        $ btnArticles��5A   5   $y�	Collapsed=�6   $ directeur, g.stock��6J   $��Articles��6�   #���  6�   $��0 5 0 5q�6�   ��6c   �� *ArticlesCommand+6�   	� 5B      -   5        $ 
btnClients��5B   5   $y�	Collapsed=�6   $ caissiere, directeur��6I   $��Clients��6�   #���  6�   $��0 5 0 5q�6�   ��6d   �� *ClientsCommand+6�   	� 5C      -	   5        $ btnFournisseurs��5C   5   $y�	Collapsed=�6   $ directeur, g.stock��6N   $��Fournisseurs��6�   #���  6�   $��0 5 0 5q�6�   ��6g   �� *FournisseursCommand+6�   	� 5D      -
   5        $ btnAppro��5D   5   $y�	Collapsed=�6   $ directeur, g.stock��6G   $��Approvisionnements��6�   #���  6�   $��0 5 0 5q�6�   ��6`   �� *ApprovisionnementsCommand+6�   	� 5E      -   5        $ btnFacturation��5E   5   $y�	Collapsed=�6   $ 	caissiere��6M   $��Facturation��6�   #���  6�   $��0 5 0 5q�6�   ��6]   �� *FacturationCommand+6�   	� 5F      -   5        $ btnHistorique��5F   5   $y�	Collapsed=�6   $ directeur, comptable��6L   $��
Historique��6�   #���  6�   $��0 5 0 5q�6�   ��6g   �� *HistoriqueCommand+6�   	� 5G      -   5        $ btnUtilisateurs��5G   5   $y�	Collapsed=�6   $ directeur, rh��6N   $��Utilisateurs��6�   #���  6�   $��0 5 0 5q�6�   ��6b   �� *UtilisateursCommand+6�   	� 5H      -   5        $ 	btnLogout��5H   5   $y�	Collapsed=�6   $	 all��6H   $��Déconnexion��6S   #���  6i   $��0 5 0 5q�6�   6�   5I      �� 5K      -   5         ��Name$ Pages��5K      $��1��5M      $��1��5N      ��5L      �� *CurrentView+5P      �� 5Q      $��2��6   
�������._�5R      �� $��0��6   $��1��6*   $��Right=�6:   $	��Top=�6V   $��0,5,10,0q�6n   $��30��6�   $ 
Horizontal=�6�   $��RightToLeft=�6�   .+�5S      �� -   5         ��Name$ btnClose��5S        IconButtonsStyle#��[ 6/    	 close#���  6Y   $ IsCloseButton��6�   �� 5T      -   5        $ 
btnRestore��5T      $	��5,0q�61   ��5U      �� 5V      " ��6$    �� BasedOn# [ 6A   .�5W   "   ��  � ��  maximize# �  6<    �� Triggers 5X   "   �� 5Y   &    �� Binding 62   ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized6i   .a�5Z   *   ��  � ��  restore# �  6D   5[   '   5]      5_      �� 5`      -   5        $ btnMinimize��5`      #���  62     minimize#���  6]   6�   5a      5b      5c      5d      5e      