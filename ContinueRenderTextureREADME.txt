
The cause of the bug is that the FX_standard material isn't transparent.

Do this when you want to continue working on the render texture:

1. On the main camera at culling mask, untick "ItemsToHold"

2. Enable HoldingCamera

3. In PickUpStick script do "gameObject.transform.parent = holdingCamera.transform;" instead of the current line 
   (so it parents the holdingCamera instead of the main camera)

4. enable the RenderTexture / Raw Image in canvas