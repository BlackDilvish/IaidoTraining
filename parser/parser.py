import json

STEPS = 2

def parse_json_to_csharp(json_file, list_name):
    with open(json_file, 'r') as file:
        data = json.load(file)
    
    vectors = data[list_name]
    vector_list = [f'new Vector3({vector["x"]}f, {vector["y"]}f, {vector["z"]}f), ' for vector in vectors]

    return f'new List<Vector3>() {{ {"".join(vector_list)} }},'
        
def compose_final_list(vectors, list_name, output_file):
    list = "private static List<List<Vector3>> " + list_name + " = new List<List<Vector3>>() {" + "".join(vectors) + "};\n"
    
    with open(output_file, 'a') as file:
        file.write(list)

rightHandMoves = []
kissakiMoves = []

for i in range(STEPS):
    file = f'moveData{i}.json'
    rightHandMoves.append(parse_json_to_csharp(file, "rightHandMoves"))
    kissakiMoves.append(parse_json_to_csharp(file, "kissakiMoves"))

compose_final_list(rightHandMoves, "rightHandMoves", "moves.cs")
compose_final_list(kissakiMoves, "kissakiMoves", "moves.cs")