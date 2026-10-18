CORALINE SCREENSHOT-INSPIRED ASSET PACK
=======================================

Deliverables
------------
01_BeldamCreature.fbx       Tall spider-like gothic antagonist; separate modeled parts and armature.
02_CoralineChild.fbx        Stylized child with blue bob, yellow raincoat/trousers, boots, backpack and armature.
03_GothicFireplace.fbx      Modular surround, mantel, supports, grate, logs and separate green flame tongues.
04_GothicWallPanel_Straight.fbx
05_GothicWallPanel_Mirrored.fbx
06_Modular_StoneWall_Straight.fbx
07_Modular_InsideCorner.fbx
08_Modular_OutsideCorner.fbx
09_Modular_Floorboards.fbx
10_Modular_LowerMolding.fbx
11_Modular_TallWallTrim.fbx
12_Modular_CeilingBeam.fbx
13_Prop_OrnateMirror.fbx
14_Prop_AntiqueClock.fbx
15_Prop_WallSconce.fbx

GothicCoraline_AssetLibrary.blend is the editable Blender source, organized into numbered collections.
Textures/ contains the companion authored PNG maps. The FBX exports carry their material assignments;
if Unity prompts for texture extraction, choose a folder under your Unity project's Assets directory.

Unity import
------------
1. Copy the FBX files and Textures folder into your Unity project's Assets folder.
2. Select each FBX and set the Model Importer scale to 1. The scene is modeled in meter-scale units.
3. For the two characters, import the armature and meshes together. Set Rig > Animation Type to Generic
   unless you replace the provided armature with your own humanoid rig.
4. Green flame meshes are geometry with a green material; add a Unity emission map/material to make them glow.
5. Modular wall sections are 3 m wide and about 3.2 m tall. Floor module is 3 m square.
   Duplicate and align the wall, floor, molding, trim, and beam modules as needed.
6. The mirror glass uses a dark reflective surface. Assign a Unity reflection probe or custom shader
   if you want visible reflections.

Notes
-----
These are original stylized game-ready blockout/detail meshes guided by the supplied screenshot, not extracted
movie assets. Object names are descriptive; characters are built from separately editable mesh parts.
Use the FBX files for Unity and the .blend file for edits. The flame geometry does not include baked light.

Animated Green Fireplace
------------------------
03_GothicFireplace.fbx now includes a 48-frame looping flame-shape animation and an animated green point light.
In Unity, select the FBX, open the Animation tab, enable Import Animations, and enable Loop Time on the imported clip.
The FBX does not carry Blender shader emission curves into Unity, so GreenFireFlicker.cs supplies a matching
Unity emission pulse and point-light flicker. Copy the script into Assets, attach it to the fireplace root,
and assign the flame renderers and imported fire light (or leave the fields empty for automatic discovery).

Fire brightness update
----------------------
The fireplace flames are larger and the Blender emission is stronger, with a brighter green point-light pulse.
The Unity helper defaults are also increased (HDR emission strength 14 and light intensity 8). On a camera with
Bloom enabled, this produces the green halo; without Bloom, the emissive mesh remains bright saturated green.
