# frestockev2
Projekt zrealizowany na przedmiot Aplikacje Internetowe w Technologi .NET

Projekt jest napisany w ASP.NET Core v2.2 i jest to projekt prostego stocka ze zdjęciami, w którym po zalogowaniu możemy szybko pobierać zdjęcia, jakie się na nim znajdują.

W projekcie występują operacje na bazie danych typu CRUD tzn. Create Read Update i Delete, Sesja/ustanowienie ciasteczka sesji i metody przekazywania parametrów POST oraz GET. Projekt bazuje na ASP.NET Core w wersji 2.2 i jest zbudowany na wzorcu MVC tzn. Model-View-Controler, czyli został podzielony na Modele oraz Widok i Kontroler. Modele są reprezentacją bazodanową, Widoki fizycznymi stronami, a Kontroler odpowiada za routing wraz z logicznymi operacjami, a także(GET/POST)

Projekt korzysta także z operacji na plikach (po stronie serwera), jQuery, HTML/CSS i Freamwork do CSS jakim jest Bootstrap.

Odwiedzający, który wejdzie na strone, ma możliwość stworzenia nowego konta, zalogowania się i może jedynie wyświetlić jakie obrazki znajdują się w bazie stocka za pomocą miniaturek (thumbnails), a także wyświetlenie obrazków po ich kategorii lub wszystkie (jQuery).
Błędne logowanie i inne komunikaty prezentowane są przez modal bootstrapa, akcji jQuery, który je wywołuje oraz przetworzony rodzaj komunikatu przez serwer.


Po poprawnym stworzeniu konta i zalogowaniu się, ustanowione zostaje ciasteczko sesyjne, które będzie trwać przez 30 minut i które posiada tylko login i id użytkownika. Taki użytkownik ma możliwość kliknięcia interesującego go zdjęcia i tym samy pobierane jest zdjęcie z serwera. Użytkownik dodatkowo dostał opcję dodania swojego zdjęcia.

Jeśli użytkownik załaduje zdjęcie i nada mu nową Kategorię np. 'buildings', to nowa kategoria zostanie dodana do bazy. Zdjęcie na serwerze zostaje zapisane w dwóch miejscach, w folderze plików o pełnej swojej rozdzielczości oraz w plikach thumnails.
Użytkownik ma możliwość wejścia na swój profil, gdzie prezentowane są tylko te obrazki, które sam dodał i z tego poziomu może wskazać który obrazek usunąć (po jego wybraniu).
