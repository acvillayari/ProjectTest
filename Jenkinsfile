pipeline {
    agent any
 
    stages {
        
        stage('SCM') {
            steps {
               git branch: 'main', url: 'https://github.com/acvillayari/ProjectTest'
            }
        }
        
         stage ('Build Net6.0') {
           steps {
            bat(script: 'dir' , returnStdout:true);
            bat(script: 'dotnet restore' , returnStdout:true);
            bat(script: 'dotnet build' , returnStdout:true);
            bat(script: 'dotnet test' , returnStdout:true);
           }
       }
       
        stage ("Docker Build") {
           
           steps{
             // docker login  
             bat(script: 'docker login --username %UserNameDockerHub% --password %PasswordDockerHub%',returnStdout:true)
             bat(script: 'docker build -t %UserNameDockerHub%/servicenet6 .' , returnStdout:true);
             bat(script: 'docker push %UserNameDockerHub%/servicenet6' , returnStdout:true);  
           }
       } 
        stage ("Deploy AKS") {
           steps {
            bat(script: 'az aks get-credentials --resource-group aforo255Devops --name kcdevops  & kubectl config get-contexts --kubeconfig=%KUBE_PATH_CONFIG%', returnStdout: true);
            bat(script: 'kubectl config use-context kcdevops  --kubeconfig=%KUBE_PATH_CONFIG%', returnStdout: true);
            bat(script: 'kubectl apply -f k8s.yml --kubeconfig=%KUBE_PATH_CONFIG%', returnStdout: true);
            bat(script: 'kubectl rollout restart deployment --kubeconfig=%KUBE_PATH_CONFIG%', returnStdout: true);
           }
       }
    }
}
