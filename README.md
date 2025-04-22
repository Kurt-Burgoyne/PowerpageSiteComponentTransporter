
# Powerpage Site Component Transporter

Transport virtual power page site components from one environment to another.

Note: This tool is used for the new model of powerpages using virtual tables, if you are looking for a tool to transfer older versions of powerpages / powerapps portals Portal record mover is my recommended tool of choice.




## Usage Steps

 1. Inside of the tool click load source on the menu bar, if you are not already connected you will be prompted to do so; this will load the different component types on the left and any website you have in the connected envrionement into the website filter.

 2. You can select which types of records you would like to retrieve on the left i.e webtemplate, basic forms, form metadata etc... for further filtering options you can also check the filters on the right side for them to apply i.e get all records modifed after a specified date.

 3. Once happy with the filtering click retrieve records in the top menu bar, this will list all site components found in the bottom right table.

 4. Check the record you wish to transfer over to the new environment.

 5. We now need to select the new envrionment, on the top menu bar you can click select target this will prompt you to select the target environment (the environment the records will be transfered to), you can confirm this has worked as target environment: in connection details will be green and display the target environment name.

 Note: if this button is greyed out it will be due to not finding a source envrionment, you can connect to a source but using xrm tool box, in the bottom left or by clicking load source and this will prompt you.

 6. Once you have a target environment and you have comfirmed all the records you want to transfer are selected in the bottom right, click transfer records this will give you an on screen message (transfering x record(s)) and once complete tell you how many records have been created, updated and any errors that may have occured.

 note: if the transfer records button is disabled, confirm you have selected a target environment.
