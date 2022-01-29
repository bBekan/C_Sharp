using _06_Interfaces;

var Workflow = new Workflow();

Workflow.Add(new UploadToCloud(), new CallWebService(), new SendEmail("bb52378@fer.hr"), new ChangeStatus());

var WorkflowEngine = new WorkflowEngine();
WorkflowEngine.Run(Workflow);

