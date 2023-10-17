import sqlite3, utils

def getSchema():
    cnn = sqlite3.connect(utils.config['db'])
    cur = cnn.cursor()
    try:
        for row in cur.execute("select name, sql from sqlite_master where type = 'table';"):
            print(row[1])
    except Exception as e:
        print(e)

    cnn.close()