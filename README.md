# RoboticsCompetitionOrganisation
Система за организация на състезания по роботика
- Регистрационна форма на отборите
  - Брой участници
  - Имена 
  - Фамилии
  - Възрастова група 
     1) група - 12-14 г.
     2) група - 15-16 г.
     3) група - 17-18 г.
     4) група - 18+
  - Име на отбор
  - Описание
  - Робот
    - бързина
    - здравина
    - интелигентност 
      Граници на точките и добавяне на точки от журито, които са фиксирани преди това.
      Да извежда изключения
  - Дисциплина
    * лабиринт
    * схватки между роботи
    
    таблица която свързва отбори с дисциплини (един отбор с един робот участва в една дисциплина)
    
  - Състезания (готова база данни)
  дисциплини
  таблица отбори-отбори (едно към много)
  нива (Първо, второ и т.н)
  време и точки (журито го казва)
  ИД на срещата
  
  - Статистика за нивата
   срещи, време и точки
   временно класиране за нивото, изиграно от всички отбори
   
   
   
   Форми:
   A.
    1. хора (имена, тел., имейли, дата на раждане за определяне на възрастова група, градове)
    2. отбори (един или повече хора)
      - име на отбора
      - име на робота
    3. състезателни дисциплини (текст и описание на дисциплина и възрастова група)
   
   
   B.
     1. състезания (име, място, дата, час, текст с описание)
     2. дисциплини (таблица едно към много)
     3. състезание плюс дисциплина, регистрираме и отбор (едно към много)
     4. срещи
        За всяко състезание + дисциплина на база регистрираните отбори Х, ще се играят срещи, които имат ниво (в едно ниво може да има повече от една схватки). За    всяка схватка пазим само време и точки и извеждаме временно класиране на ниво за всичките срещи.
   
