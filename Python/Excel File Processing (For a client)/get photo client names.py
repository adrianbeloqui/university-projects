from xlrd import open_workbook
import xlwt

all_client_info = open_workbook('ClientsInfoAllFormattedXLS.xlsx')
photo_client_name = open_workbook('Photo_Client_NamesXLS.xlsx')

all_client_info_first_sheet = all_client_info.sheet_by_index(0)

photo_client_name_first_sheet = photo_client_name.sheet_by_index(0)

count = 0

workbook = xlwt.Workbook()

sheet = workbook.add_sheet('test')
sheet.write(0, 0,'External ID')
sheet.write(0, 1,'Name')
sheet.write(0, 2,'Inmate number')

line = 1

for i in range(1, photo_client_name_first_sheet.nrows):
    row = photo_client_name_first_sheet.row_slice(i)
    photo_client_number = row[0].value
    for x in range(1, all_client_info_first_sheet.nrows):
        row2 = all_client_info_first_sheet.row_slice(x)
        all_client_name = row2[2].value
        if str(photo_client_number) in str(all_client_name):
            count += 1
            name = all_client_name.replace(photo_client_number,"")
            num = all_client_name.replace(name,"").replace(" ","")
            sheet.write(line, 0, photo_client_number)
            sheet.write(line, 1, name)
            sheet.write(line, 2, num)
            print "Row: {} ID : {} Name : {} Number : {} ".format(i,photo_client_number,name, num)
            line +=1
            continue
        

workbook.save('output.xlsx')    
print "Total amount of records : {}".format(count)
