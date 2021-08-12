pipeline {
    agent { label 'ubuntu-slave' }

    stages {
		stage ('Clean workspace') {
			steps {
				cleanWs()
			}
		}
		stage('Build') {
			steps {
				echo 'Pulling...' + env.BRANCH_NAME
				checkout scm
			 }
		 }
		stage('Test') {
		  steps {
		  		echo 'Running test ...' + env.BRANCH_NAME
		  }
		}
		stage('Docker') {
			steps {
				script {			
					if(env.BRANCH_NAME == 'dev'){
						echo "Building tag with ${env.BUILD_ID}"
						sh "aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 231587286057.dkr.ecr.us-east-1.amazonaws.com"
						sh "sudo docker build -t homework_api:dev${env.BUILD_ID} ."
						sh "docker tag homework_api:dev${env.BUILD_ID} 231587286057.dkr.ecr.us-east-1.amazonaws.com/homework_api:dev${env.BUILD_ID}"
						sh "docker push 231587286057.dkr.ecr.us-east-1.amazonaws.com/homework_api:dev${env.BUILD_ID}"
						sh "docker image rm homework_api:dev${env.BUILD_ID}"
						sh "docker image rm 231587286057.dkr.ecr.us-east-1.amazonaws.com/homework_api:dev${env.BUILD_ID}"
					}
				
				}

			}
		 } 
		 stage('Deployment') {
		 	steps {
				script{
					if(env.BRANCH_NAME == 'dev') {
						echo "Deployment to dev environment"
						configFileProvider([configFile(fileId: 'ff7cd79b-90a7-43f1-8441-d269f2069bbf', targetLocation: './config/libConfig.json')]) {}
                        configFileProvider([configFile(fileId: '47df99a3-2d66-4dd8-bd69-6f0124ddffbd', targetLocation: './config/service.json')]) {}
				  		sshPublisher(publishers: [sshPublisherDesc(configName: 'aws-api-gate-dev', transfers: [sshTransfer(cleanRemote: false, excludes: '', execCommand: '''
						  pwd
						  cd  homework_api
						  sh deploy.sh dev${BUILD_NUMBER} ''', execTimeout: 120000, flatten: false, makeEmptyDirs: false, noDefaultExcludes: false, patternSeparator: '[, ]+', remoteDirectory: 'homework_api/', remoteDirectorySDF: false, removePrefix: '', sourceFiles: 'config/*.json')], usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: true)])       
					}
					
				}

			}
		 }
		 
    }
}
