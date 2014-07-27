float4x4 worldViewProj : c0;

struct VsInput
{
	float3 Position : POSITION0;
	float4 Color : COLOR0;
};

struct VsOutput
{
	float4 Position : POSITION0;
	float4 Color : COLOR0;
};

struct PsInput
{
	float4 Color : COLOR0;
};

// Vertex Shader:
VsOutput VS(VsInput input)
{
	VsOutput output = (VsOutput)0;
	float4 position = float4(input.Position.xyz, 1.0f);
	output.Position = mul(position, transpose(worldViewProj));
	output.Color = input.Color;
	return output;
}

// Pixel Shader:
float4 PS(PsInput input) : COLOR
{
	return input.Color;
}