# Test4Service365WithSpecFlow
    this project is auto-test scripts with c# and specflow
    and this is a proto-type. 
    if possible, everything will be built on it.
    before running it, please goto https://sites.google.com/a/chromium.org/chromedriver/downloads,
    and download the proper version of chromedriver file regarding of the version of your own chrome,
    then unzip the exe file to this folder [c:\chromedriver]
    ---i am very sorry that till now lots of options and parameters are hard-coded.
    Jan 14th 2019
        I just add one environment parameter Browser for the browser type, which should be one of these
        3 values: Chrome , Firefox and IE. This parameter should be setup in Jenkins too. And if the 
        value is out of range, one error will be thrown.
        Then I use the config file to store the URL of targte web site.
    Jan 16th 2019
        I have completed one new scenario about that Customer generate one order and cancel it.
        recently, the problems are
        1.need to move all the hard-coded values into data file or config file
        2.need to study how to run scenarios in specific order
    Jan 17th 2019
        I use SeleniumExtras.PageObjects to enable pagefactory again.
        a quick update that I just fix a problem that socket exception pops when we run multiple scenarios--
        some unneccessary codes are commented, the key reason is value Driver is not set to null after code 
        Driver.Quit() is executed, then when the initBrowser() is called again, the real driver will never be
        generated.
    Jan 18th 2019
        Now I use one static class to store the values read from config file.
        And I also move lots of hard-coded data to config file and data file-- maybe I should move the data file
        name to config file too.
