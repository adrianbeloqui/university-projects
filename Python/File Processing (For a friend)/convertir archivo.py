
from xlrd import open_workbook


excel_path = raw_input('Enter EXCEL filename: ')

wb = open_workbook(excel_path)

maching_ids = []

for s in wb.sheets():
    for row in range(s.nrows):
        value  = str(s.cell_value(row, 0)).strip()
        if value.endswith(".0"):
            value = value[:-2]
        maching_ids.append(value)
    break

del wb

print ("Se cargo el archiov Excel correctamente")
txt_path = raw_input('Enter TXT filename: ')
txt = open(txt_path,'r')
print (txt_path)
new_txt_path = txt_path[:-4]
new_txt_path = new_txt_path + " PROCESADO.txt"

new_txt = open(new_txt_path, 'w')

lines = []
count = 0
for line in txt.readlines():
    line_parsed = l = line.replace('[','').replace(']','').replace('|',' ')
    line_parsed = line_parsed.split()
    found = False
    for item in maching_ids:
        if item in line_parsed[0]:
            found = True
    if found == False:
        new_txt.write(line)
        count += 1
        print ("LINEA AGREGADA " + line)

new_txt.close()
                
            
            
print ("Lineas en TXT final: " + str(count))    




