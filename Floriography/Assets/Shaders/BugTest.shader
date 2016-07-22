Shader "Thesis Jam/Bugtest"
{
	Properties
	{
		_Color ("Main Color", Color) = (1, 0.5, 0.5, 1)
	}

	Subshader
	{
		Pass
		{
			Cull Back

			Material { Diffuse [_Color] }

			Lighting On
		}
	}
}