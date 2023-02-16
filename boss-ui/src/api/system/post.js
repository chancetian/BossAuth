import request from '@/utils/request'

// 查询岗位列表
export function listPost(query) {
  return request({
    url: '/v1/Position/GetList',
    method: 'post',
    data: query
  })
}

// 查询岗位详细
export function getPost(postId) {
  return request({
    url: '/v1/Position/' + postId,
    method: 'get'
  })
}

// 新增岗位
export function addPost(data) {
  return request({
    url: '/v1/Position',
    method: 'post',
    data: data
  })
}

// 修改岗位
export function updatePost(data) {
  return request({
    url: '/v1/Position',
    method: 'put',
    data: data
  })
}

// 删除岗位
export function delPost(postId) {
  return request({
    url: '/v1/Position/' + postId,
    method: 'delete'
  })
}
