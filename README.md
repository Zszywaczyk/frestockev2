# frestockev2
Projekt zrealizowany na przedmiot Aplikacje Internetowe w Technologi .NET

Projekt jest napissany w ASP.NET Core v2.2 i jest to projekt prostego stocka ze zdjęciami w którym po zalogowaniu możemy szybko pobierać zdjęcia jakie się na nim znajdują.

W projekcie występują operacje na bazie danych typu CRUD tzn. Create Read Update i Delete, Sesja/ustanowienie ciasteczka sesji i metody przekazywania parametrów POST oraz GET.
Projekt bazuje na ASP.NET Core w wersji 2.2 i jest zbudowany na wzorcu MVC tzn. Model-View-Controler czyli został podzielony na Modele oraz Widok i Kontroler.
Modele są reprezentacją bazodanową, Widoki fizycznymi stronami, a Kontroler odpowiada za routing wraz z logicznymi operacjami a także(GET/POST)

Projekt korzysta także z operacji na plikach (po stronie serwera), jQuery, HTML/CSS i Freamwork do CSS jakim jest Bootstrap 

Odwiedzający który wejdzie na strone ma możliwość stworzenia nowego konta, zalogowania się i może jedynie wyświetlić jakie obrazki znajdują się w bazie stocka za pomocą miniaturek (thumbnails) a także wyświetlenie obrazków po ich kategorii lub wszystkie (jQuery). 
Błędne logowanie i inne komunikaty prezentowane są przez modal bootstrapa, akcji jQuery który je wywołuje oraz przetworzony rodzaj komunikatu przez serwer. 
Po poprawnym stworzeniu konta
