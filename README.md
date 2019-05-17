# arkanoid (Unity 2019.1.2f1)



При нажатии на кнопку Start вызывается GameController.TryStartGame().
Игра стартует, остальные контроллеры по событию GameController.OnGameStartEvent начинают выполнять свои функции (спаун кирпичей и шарика).

По выполнению определённых действий, таких как 
1. Попадание шарика на красную полосу
2. Попадание кирпичей на красную полосу
3. Уничтожение всех кирпичей

триггерится событие в GameModel (OnGameWonEvent, OnGameLostEvent. В зависимости от результата).
По этим событиям срабатывает GameController.TryEndGame().

Есть возможность сконфигурировать геймплей, шарик и кирпичи. Их конфиги вынесены в соответствующие ScriptableObject (Assets/Configs).

