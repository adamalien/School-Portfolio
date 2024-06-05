The only changes to make to the code to allow it to run properly will be to change the file path in 
public void importFromFile(String fname)
to make sure that the file is coming from somewhere that you can access it. Additionally, when generateReport is called,
the file will be saved in the folder where the code is being run from. Otherwise, all you have to do is run it!