NOTE 1:

When implementing new enemies, remember that every enemy that needs to have collision with the floor and other objects in general should have a main object with a trigger collider, which serves the purpose to check for collisions with the player, and a child object, called EnemyCollision, with a normal collider which is used for real collisions. You should also remember to give the child object a script called "script_EnemyCollision", which makes so that the player isn't pushed around by enemies and the same goes for other interactable objects.

NOTE 2:

Remember to give all new enemies and interactable objects a RigidBody component, because they need it make use of the RelativeSpeed script component.