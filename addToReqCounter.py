from datetime import datetime as dt
import csv

row = [str(dt.now()),str(True),'dev']
with open('requestLog.csv', 'a', newline='') as f:
    writer = csv.writer(f)
    writer.writerow(row)
