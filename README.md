# MyLittleTanky

 My little sweet terminator of enviroment

# Project description

 The game where the hero is a small tank, it will rely on survival where on each hill will be waiting for him danger. 
 We will have to take care of the fuel and ammunition for our small distributor, the assumption is that everything 
 will be destroyed even where we can replenish the supplies will also have to be careful not to damage them.

 Embedding game time:
 Initially, "new age" where the rarity is electromagnetic and electromagnetic shield against bullets.
 Game begins to be a tank that will not be brand new for its time.

#Object list

Legend: Name(Function in Game)
```
	{
	Abilities
	}
```

Hero(User )
```
{
  * Possibility of a shot
  * Has ammunition
  * Has gas
  * Has technical verchicle state (HP)
  * Has own level
  * Has ability to had own value
  * Has interchangeable components (tracks / gravity drive, engine / atomic engine, ammunition cannon / laser cannon)
  * Verchicle repair
  * Pick up objects (OnTriggerEnter, ButtonDown)
  * Ability of buying fuel, ammunition, repair itself
}
```
  
Enemy (Tank)
```
{
  * Possibility of a shot
  * Has ammunition
  * Has gas
  * Has technical verchicle state (HP)
  * Has own level
  * Has random range of value between 0 -> 50 unit
  * After defeat has random range of ammunition or fuel berween od 0 -> 300 unit depend of object level
}
```

Enemy(Bunkier)
```
{
  * Possibility of a shot
  * Has ammunition
  * Has technical state (HP)
  * Has own level
  * After defeat has random range of ammunition or value between 0 -> 200 unit depend of object level
}
``` 

Enemy (Mine)
```
{
  * Deals damage from an explosion
  * Damages vehicle components
}
```

# Files

  * Place Holder & 1h
  * Test scene  & 1h
    # Game models
     - [ ] Tank & 10h per one
     - [ ] Tank equipment 
      - [ ] Tank track & 2h
       - [ ] Tower two kinds & 1h per once
     - [ ] Mines two kinds  & 2h per once
     - [ ] Bunker two kinds & 4h per once
    # Scripts
     - [X] GUIController & 2h
        - [X] Load level
        - [ ] Settings
           - [ ] Sound volume
           - [ ] SFX volume
        - [X] Exit
     - [ ] TankController & 5h 
        - [X] Tank move
        - [ ] Rotate tank tower
        - [ ] Claim equipment
        - [ ] Tank attack
        - [ ] Tank hp
        - [ ] Tank fuel
        - [ ] Enemy detector (laser build only)
     - [ ] AITankController & 1h 
        - [X] AI range (coolider)
        - [ ] AI attack (look at tag "Player", make action attack)
        - [ ] AI hp () at life end
     - [X] PlayersController
	    - [X] Hp
		- [X] Fuel
		- [X] Attack
		- [X] Ammunation
     - [ ] Sound control
        - [ ] Main mixer
        - [ ] AI detect sound
    # Practicle system
     - [ ] Explosion FX (standard amunnation) & 5h
     - [ ] Explosion FX (mine) & 5h
     - [ ] Schoot FX (laser tower) & 5h
     - [ ] Move FX & 5h
    # Sound System
     - [ ] Main menu sound theme
     - [ ] In game sounds
        - [ ] Sand sound
        - [ ] Forest sound
        - [ ] Hill sound
     - [ ] Explosion FX
        - [ ] Mine sound
        - [ ] Mine defeat
        - [ ] Bunker attack sound
        - [ ] Bunker defeat
     - [ ] AI and hero
        - [ ] Ammunition sound
        - [ ] Laser sound
        - [ ] Movement sound
        - [ ] AI detect (hero only)
         
Time totally: 110h + possible further development () w/o sound

# Placeholder

Models:
* Tank (hight poly + animation) 
* Enviroment buildings (low poly)
* Enviroment (low poly)
* Simple textures

# Links

  *Damage mechanics (Static Objects and AI)
  http://www.dofactory.com/net/observer-design-pattern
  https://www.codeproject.com/Articles/866547/Publisher-Subscriber-pattern-with-Event-Delegate-a
  * View changes before click play
  https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html
  * Shaders
  https://docs.unity3d.com/Manual/ShadersOverview.html
  * Camera view
  http://www.lighthouse3d.com/tutorials/view-frustum-culling/