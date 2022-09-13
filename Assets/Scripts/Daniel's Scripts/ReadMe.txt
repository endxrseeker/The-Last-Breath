
==== Oxygen System Important Information ====

In order to make the oxygen system function in your own scene...
1. The player object must have the "PlayerOxygenManager" script and be on Layer 7
2. Drag and drop the oxygen canister from inside the 'Prefabs' folder into the scene

You can easily play around with the settings of the oxygen system through the inspector:
- To adjust the maximum oxygen of either the player or the oxygen canisters, change the "Maximum Player Oxygen" variable on the player or "Total Oxygen In Canister" variable on the canister respectively.
- To adjust the amount of oxygen the player uses per second, change the "Player Oxygen Drain Rate" variable on the player. (Higher numbers result in a faster drain rate)
- To adjust the rate at which the player uses oxygen from canisters, change the "Canister Recovery Rate" variable on the player. (Higher numbers result in faster drain rate)

Aside from the "Current Player Oxygen" variable on the player and the "Current Oxygen In Canister" variable on the canister, do not adjust any other variables. They were not designed to be altered and
will either do nothing or break the program.



==== Oxygen System Controls ===

Walk over a canister to collect it

- Right Mouse Button -> Breathe from the selected canister
- Middle Mouse Button -> Drop the selected canister

When you have two canisters in hand...
- Scroll Wheel -> Change selected canister

There is currently a debug tool in the "PlayerOxygenManager" script...
Right Mouse Button -> Lower the player's current oxygen by 10 units



==== Known Bugs ====

Collecting a canister you previously dropped results in the canister slowly floating away