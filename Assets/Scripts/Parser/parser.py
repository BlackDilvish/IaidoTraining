import json
import os
import UnityEngine

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

for filename in os.listdir(UnityEngine.Application.persistentDataPath):
    if filename.startswith('moveData'):
        file = os.path.join(UnityEngine.Application.persistentDataPath, filename)
        rightHandMoves.append(parse_json_to_csharp(file, "rightHandMoves"))
        kissakiMoves.append(parse_json_to_csharp(file, "kissakiMoves"))

movesPath = UnityEngine.Application.dataPath + "/Scripts/Parser/Moves.cs"
compose_final_list(rightHandMoves, "rightHandMoves", movesPath)
compose_final_list(kissakiMoves, "kissakiMoves", movesPath)